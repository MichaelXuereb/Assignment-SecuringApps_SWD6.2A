using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private IMapper _autoMapper;
        private ISubmissionsRepository _subrepo;
        public SubmissionsService(ISubmissionsRepository subrepo, IMapper autoMapper)
        {
            _subrepo = subrepo;
            _autoMapper = autoMapper;
        }

        public void AddSubmission(SubmissionViewModel model)
        {
            var submission = _autoMapper.Map<Submission>(model);
            submission.TaskFK = submission.Task.Id;
            submission.Task = null;

            _subrepo.AddSubmission(submission);
        }

        public SubmissionViewModel GetSubmission(Guid id)
        {
            var sb = _subrepo.GetSubmission(id);
            if (sb == null) return null;
            else
            {
                var result = _autoMapper.Map<SubmissionViewModel>(sb);
                return result;
            }
        }
    }
}
