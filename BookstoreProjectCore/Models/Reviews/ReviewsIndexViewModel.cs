using System.ComponentModel.DataAnnotations;

namespace BookstoreWebApp.Models.Reviews
{
    public class ReviewsIndexViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public string Username { get; set; } = null!;
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(250, ErrorMessage = "The review can be a maximum of 250 characters.")]
        public string Text { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        public DateTime CreatedOn { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public Guid BookId { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public bool IsAnonymous { get; set; }
    }
}
