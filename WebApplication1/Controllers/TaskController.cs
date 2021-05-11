using System;
using System.Collections.Generic;
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
using WebApplication1.Utility;

namespace WebApplication1.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITasksService _taskService;
        private readonly IWebHostEnvironment _host;
        private readonly ILogger<TasksController> _logger;
        private readonly IMembersService _memService;
        public TasksController(ITasksService taskService, IWebHostEnvironment host, ILogger<TasksController> logger, IMembersService memService)
        {
            _logger = logger;
            _host = host;
            _taskService = taskService;
            _memService = memService;
        }

        [Authorize]
        public IActionResult Index()
        {

            string email = User.Identity.Name;
            var student = _memService.GetMember(email);

            if (student == null){
                var list = _taskService.GetTasks(email);
                return View(list);
            }
            else{
                string teaEmail = student.TeacherEmail;
                var list = _taskService.GetTasks(teaEmail);
                return View(list);
            }
            
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

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress[] addr = ipEntry.AddressList;

            if (data.Deadline > DateTime.Now)
            {
                if (ModelState.IsValid)
                {
                    _taskService.AddTask(data);
                    _logger.LogInformation("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nTask inserted successfully");
                    TempData["message"] = "Task inserted successfully";
                    return View();
                }
                else
                {
                    _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nCheck your input. Operation failed");
                    ModelState.AddModelError("", "Check your input. Operation failed");
                    return View(data);
                }
            }
            else {
                _logger.LogError("IP: " + addr[1].ToString() + "\nTime: " + DateTime.Now + "\nUser: " + User.Identity.Name + "\nIncorrect Datetime");
                ModelState.AddModelError("", "Incorrect Datetime");
                return View(data);
            }
        }

    }
}
