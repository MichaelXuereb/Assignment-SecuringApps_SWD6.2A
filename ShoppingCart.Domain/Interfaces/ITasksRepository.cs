using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ITasksRepository
    {
        Task GetTask(Guid id);
        IQueryable<Task> GetTasks();
        Guid AddTask(Task t);
        void DeleteTask(Guid id);
    }
}
