using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class SubmissionViewModel
    {
        public Guid Id { get; set; }
        public string TaskId { get; set; }
        public TaskViewModel Task { get; set; }
        [Required]
        public string Description { get; set; }
        public string File { get; set; }
        public string Signature { get; set; }
        public string Email { get; set; }
    }
}
