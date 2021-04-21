using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ISubmissionsService
    {
        SubmissionViewModel GetSubmission(Guid id);
        IQueryable<SubmissionViewModel> GetSubmissions(Guid id);
        IQueryable<SubmissionViewModel> GetSubmissions(string email);

        void AddSubmission(SubmissionViewModel model);
    }
}
