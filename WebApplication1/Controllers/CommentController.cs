using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace WebApplication1.Controllers
{
    public class CommentController : Controller
    {
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<CommentController> _logger;
        private readonly ICommentService _comService;
        private readonly ISubmissionsService _subService;

        public CommentController(IWebHostEnvironment host, ILogger<CommentController> logger, ICommentService comService, ISubmissionsService subService)
        {
            _logger = logger;
            _host = host;
            _comService = comService;
            _subService = subService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(Guid id)
        {
            var comments = _comService.GetComments(id);
            ViewBag.Comments = comments;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(CommentViewModel data, Guid id)
        {
            data.Submission = _subService.GetSubmission(id);
            data.Email = User.Identity.Name;

            if (ModelState.IsValid){
                _comService.AddComment(data);
                TempData["feedback"] = "Comment was added successfully";
                ModelState.Clear();
            }else{
                TempData["warning"] = "Error while adding product to Database";
            }

            var comments = _comService.GetComments(id);
            ViewBag.Comments = comments;

            return View();
        }
    }
}
