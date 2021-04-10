using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShoppingCart.Application.ViewModels
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Email { get; set; }
    }
}
