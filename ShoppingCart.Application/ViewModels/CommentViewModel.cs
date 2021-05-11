using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class CommentViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Comment { get; set; }
        public string SubmissionId { get; set; }
        public SubmissionViewModel Submission { get; set; }
        public string Email { get; set; }
    }
}
