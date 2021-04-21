using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public String comment { get; set; }

        [Required]
        public virtual Submission Submission { get; set; }

        [ForeignKey("Submission")]
        public Guid SubmissionFK { get; set; }

        [Required]
        public String email { get; set; }
    }
}
