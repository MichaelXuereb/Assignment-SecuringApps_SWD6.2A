using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionsService _subService;
        private readonly ITasksService _taskService;
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<SubmissionController> _logger;

        public SubmissionController(ISubmissionsService subService, ITasksService taskService, IWebHostEnvironment host, ILogger<SubmissionController> logger)
        {
            _logger = logger;
            _host = host;
            _subService = subService;
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(Guid id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(IFormFile file, SubmissionViewModel data, Guid id)
        {
            data.Task = _taskService.GetTask(id);
            
            if (ModelState.IsValid)
            {
                string uniqueFilename;
                if (System.IO.Path.GetExtension(file.FileName) == ".pdf" && file.Length < 1048576)
                {
                    //137 80 78 71 13 10 26 10
                    byte[] whiteList = new byte[] { 37, 80, 68, 70};
                    if (file != null) {
                        using (var f = file.OpenReadStream()) {
                            byte[] buffer = new byte[4];
                            f.Read(buffer, 0, 4);

                            for (int i = 0; i < whiteList.Length; i++)
                            {
                                if (whiteList[i] == buffer[i])
                                {}
                                else
                                {
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
                                using (FileStream fsOut = new FileStream(absolutePath, FileMode.CreateNew, FileAccess.Write))
                                {
                                    f.CopyTo(fsOut);
                                }

                                f.Close();
                            }
                            catch (Exception e)
                            {
                                _logger.LogError(e, "Error happend while saving file.");
                                return View("Error", new ErrorViewModel() { Message = "Error while saving the file. Try again later" });
                            }
                        }
                    }

                    _subService.AddSubmission(data);
                    TempData["message"] = "Assignment submitted successfully";
                    return View();
                }else{
                    ModelState.AddModelError("file", "File is not valid and acceptable or size is greater than 10Mb");
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError("", "Check your input. Operation failed");
                return View(data);
            }
        }
    }
}
