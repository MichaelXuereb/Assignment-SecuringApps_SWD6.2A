using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;

namespace WebApplication1.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _taskService;
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<TasksController> _logger;
        public TasksController(ITasksService taskService, IWebHostEnvironment host, ILogger<TasksController> logger)
        {
            _logger = logger;
            _host = host;
            _taskService = taskService;
        }

        public IActionResult Index()
        {
            var list = _taskService.GetTasks();
            return View(list);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Create(TaskViewModel data){
            data.Email = User.Identity.Name;

            if (ModelState.IsValid)
            {
                _taskService.AddTask(data);

                TempData["message"] = "Product inserted successfully";
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Check your input. Operation failed");
                return View(data);
            }
        }

    }
}
