using System.ComponentModel.DataAnnotations;

namespace BookstoreProjectCore.Models.Authors
{
    public class AuthorsEditViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "The name can be a maximum of 50 characters.")]
        public string FullName { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(800, ErrorMessage = "The biography can be a maximum of 800 characters.")]
        public string Biography { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "The nationality can be a maximum of 50 characters.")]
        public string Nationality { get; set; } = null!;

        [Url(ErrorMessage = "Invalid URL address.")]
        public string ImageUrl { get; set; } = null!;
    }
}
