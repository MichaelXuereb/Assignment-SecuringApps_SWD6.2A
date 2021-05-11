using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using WebApplication1.Models;
using WebApplication1.Utility;
using WebApplication1.ActionFilters;

namespace WebApplication1.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionsService _subService;
        private readonly IMembersService _memService;
        private readonly ITasksService _taskService;
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<SubmissionController> _logger;

        public SubmissionController(ISubmissionsService subService, IMembersService memService, ITasksService taskService, IWebHostEnvironment host, ILogger<SubmissionController> logger)
        {
            _logger = logger;
            _host = host;
            _subService = subService;
            _taskService = taskService;
            _memService = memService;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "TEACHER")]
        public IActionResult TeacherSub(string id) {
            string idDec = Encryption.SymmetricDecrypt(id);
            Guid newGuid = Guid.Parse(idDec);
            var list = _subService.GetSubmissions(newGuid);
            return View(list);
        }


        [studentSubmissions]
        [Authorize(Roles = "STUDENT")]
        public IActionResult StudentSub()
        {
            string email = User.Identity.Name;
            var list = _subService.GetSubmissions(email);
            return View(list);
        }


        [Authorize]
        public IActionResult Download(string idEnc)
        {

            string idDec = Encryption.SymmetricDecrypt(idEnc);
            Guid id = Guid.Parse(idDec);

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            var sub = _subService.GetSubmission(id);
            string absolutePath = @"ValuableFiles\" + sub.File;

            FileStream fs = new FileStream(absolutePath, FileMode.Open, FileAccess.Read);
            MemoryStream toDownload = new MemoryStream();
            fs.CopyTo(toDownload);
            string email = sub.Email;
            var member = _memService.GetMember(email);

            bool pass = Encryption.VerifyData(toDownload, member.PublicKey, sub.Signature);
            MemoryStream actualFile = Encryption.HybridDecrypt(toDownload, member.PrivateKey);
            

            if (pass == true)
            {
                _logger.LogInformation("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nPDF downloaded");
                return File(actualFile, "application/octet-stream", Guid.NewGuid() + ".pdf");
            }
            else {
                _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nSomething went wrong");
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Upload(string idEnc)
        {
            SubmissionViewModel myModel = new SubmissionViewModel();
            myModel.TaskId = idEnc;
            return View(myModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Upload(IFormFile file, SubmissionViewModel data, string idEnc)
        {
            string idDec = Encryption.SymmetricDecrypt(idEnc);
            Guid id = Guid.Parse(idDec);

            SubmissionViewModel myModel = new SubmissionViewModel();
            myModel.TaskId = idEnc;

            data.Task = _taskService.GetTask(id);
            data.Email = User.Identity.Name;
            
            var member = _memService.GetMember(data.Email);

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            if (data.Task.Deadline > DateTime.Now)
            {
                if (ModelState.IsValid)
                {
                    if (file != null)
                    {

                        string uniqueFilename;
                        if (System.IO.Path.GetExtension(file.FileName) == ".pdf" && file.Length < 1048576)
                        {
                            //137 80 78 71 13 10 26 10
                            byte[] whiteList = new byte[] { 37, 80, 68, 70 };
                            if (file != null)
                            {
                                MemoryStream userFile = new MemoryStream();
                                using (var f = file.OpenReadStream())
                                {

                                    byte[] buffer = new byte[4];
                                    f.Read(buffer, 0, 4);

                                    for (int i = 0; i < whiteList.Length; i++)
                                    {
                                        if (whiteList[i] == buffer[i])
                                        { }
                                        else
                                        {
                                            _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nFile is not valid and accapteable");
                                            ModelState.AddModelError("file", "file is not valid and accapteable");
                                            return View();
                                        }
                                    }

                                    f.Position = 0;

                                    //uploading the file
                                    uniqueFilename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                                    data.File = uniqueFilename;

                                    string absolutePath = @"ValuableFiles\" + uniqueFilename;
                                    try
                                    {
                                        file.CopyTo(userFile);
                                        var encryptedFileMemoryStream = Encryption.HybridEncrypt(userFile, member.PublicKey);
                                        System.IO.File.WriteAllBytes(absolutePath, encryptedFileMemoryStream.ToArray());
                                        data.Signature = Encryption.SignData(encryptedFileMemoryStream, member.PrivateKey);
                                        f.Close();
                                    }
                                    catch (Exception e)
                                    {
                                        _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nError happend while saving file.");
                                        return View("Error", new ErrorViewModel() { Message = "Error while saving the file. Try again later" });
                                    }
                                }
                            }
                            _subService.AddSubmission(data);
                            _logger.LogInformation("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nAssignment submitted successfully.");
                            TempData["message"] = "Assignment submitted successfully";
                            return View(myModel);
                        }
                        else
                        {
                            _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nFile is not valid and acceptable or size is greater than 10Mb");
                            ModelState.AddModelError("file", "File is not valid and acceptable or size is greater than 10Mb");
                            return View(myModel);
                        }
                    }
                    else {
                        _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nNo file was selected");
                        ModelState.AddModelError("file", "No file was selected");
                        return View(myModel);
                    }
                }
                else
                {
                    _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nOperation failed due to input error.");
                    ModelState.AddModelError("", "Check your input. Operation failed");
                    return View(myModel);
                }
            }
            else {
                _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nDeadline expired");
                ModelState.AddModelError("", "Sorry, deadline has been expired.");
                return View(myModel);
            }
        }
    }
}
