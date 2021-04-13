using ShoppingCart.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface ISubmissionsService
    {
        SubmissionViewModel GetSubmission(Guid id);
        void AddSubmission(SubmissionViewModel model);
    }
}
