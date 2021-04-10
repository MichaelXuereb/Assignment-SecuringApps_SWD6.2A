using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class TasksService : ITasksService
    {
        private IMapper _autoMapper;
        private ITasksRepository _taskrepo;
        public TasksService(ITasksRepository taskrepo, IMapper autoMapper)
        {
            _taskrepo = taskrepo;
            _autoMapper = autoMapper;
        }

        public void AddTask(TaskViewModel model)
        {
            _taskrepo.AddTask(_autoMapper.Map<Task>(model));
        }

        public TaskViewModel GetTask(Guid id)
        {

            var p = _taskrepo.GetTask(id);
            if (p == null) return null;
            else
            {
                var result = _autoMapper.Map<TaskViewModel>(p);
                return result;
            }
        }

        public IQueryable<TaskViewModel> GetTasks()
        {
            return _taskrepo.GetTasks().ProjectTo<TaskViewModel>(_autoMapper.ConfigurationProvider);
        }
    }
}
