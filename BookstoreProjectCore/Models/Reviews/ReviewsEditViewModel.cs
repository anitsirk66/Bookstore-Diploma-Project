using BookstoreProjectData.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Reviews
{
    public class ReviewsEditViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(250, ErrorMessage = "The title can be a maximum of 250 characters.")]
        public string Text { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        public string UserName { get; set; } = null!;
        public string UserId { get; set; } = null!;

    }
}
