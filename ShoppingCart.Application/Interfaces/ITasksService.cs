﻿using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ITasksService
    {
        IQueryable<TaskViewModel> GetTasks();
        IQueryable<TaskViewModel> GetTasks(string email);
        TaskViewModel GetTask(Guid id);
        void AddTask(TaskViewModel model);
    }
}
