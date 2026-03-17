using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Reviews
{
    public class ReviewsCreateViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(250, ErrorMessage = "The review can be a maximum of 250 characters.")]
        public string Text { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public bool IsAnonymous { get; set; }

    }
}
