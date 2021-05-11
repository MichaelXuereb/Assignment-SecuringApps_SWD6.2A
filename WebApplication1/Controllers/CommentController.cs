using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using WebApplication1.ActionFilters;
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    public class CommentController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _comService;
        private readonly ISubmissionsService _subService;
        private readonly ITasksService _tService;
        public CommentController(IWebHostEnvironment host, ILogger<CommentController> logger, ICommentService comService, ISubmissionsService subService, ITasksService taskService)
        {
            _logger = logger;
            _host = host;
            _comService = comService;
            _subService = subService;
            _tService = taskService;
        }

        [HttpGet]
        [Authorize]
        [CommentsAuthorize]
        public IActionResult Create(string idEnc)
        {
            string idDec = Encryption.SymmetricDecrypt(idEnc);
            Guid id = Guid.Parse(idDec);

            //var sub = _subService.GetSubmission(id);
            //string email = User.Identity.Name;

            var comments = _comService.GetComments(id);
            ViewBag.Comments = comments;
            CommentViewModel myModel = new CommentViewModel();
            myModel.SubmissionId = idEnc;
            return View(myModel);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        [CommentsAuthorize]
        public IActionResult Create(string idEnc, CommentViewModel data)
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            string idDec = Encryption.SymmetricDecrypt(idEnc);
            Guid id = Guid.Parse(idDec);

            data.Submission = _subService.GetSubmission(id);
            data.Email = User.Identity.Name;

            if (ModelState.IsValid){
                _comService.AddComment(data);
                _logger.LogInformation("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nComment was added successfully");
                TempData["feedback"] = "Comment was added successfully";
                ModelState.Clear();
            }else{
                _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nError while adding product to Database");
                TempData["warning"] = "Error while adding product to Database";
            }

            CommentViewModel myModel = new CommentViewModel();
            myModel.SubmissionId = idEnc;

            var comments = _comService.GetComments(id);
            ViewBag.Comments = comments;

            return View(myModel);
        }
    }
}
