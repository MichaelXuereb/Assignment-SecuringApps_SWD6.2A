using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Submission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [ForeignKey("Task")]
        public Guid TaskFK { get; set; }
        public virtual Task Task { get; set; }
        public string description { get; set; }
        public string file { get; set; }
        public String email { get; set; }
    }
}
