using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public SubmissionViewModel Submission { get; set; }
        public string Email { get; set; }
    }
}
