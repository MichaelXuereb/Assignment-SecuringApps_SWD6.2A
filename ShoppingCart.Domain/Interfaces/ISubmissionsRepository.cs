using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Domain.Interfaces
{
    public interface ISubmissionsRepository
    {
        Submission GetSubmission(Guid id);
        void AddSubmission(Submission sb);
    }
}
