using BookstoreProjectData.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreProjectCore.Models.Books
{
    public class BooksIndexViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "The title can be a maximum of 50 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [Range(typeof(decimal), "0.01", "2000", ErrorMessage = "The price can only be between 0.01 and 2000.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Url(ErrorMessage = "Invalid URL adress")]
        public string CoverImageUrl { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        public string AuthorName { get; set; } = null!;
        
        //synopsis
        //genre name
        //promotion percentage
    }
}
