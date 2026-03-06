using BookstoreProjectData.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookstoreProjectCore.Models.Books
{
    public class BooksCreateViewModel
    {
       
        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.01", "2000")]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string CoverImageUrl { get; set; } = null!;

        [Required]
        [MaxLength(1000)]
        public string Synopsis { get; set; } = null!;


        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public Guid GenreId { get; set; }


        public Guid? PromotionId { get; set; }

    }
}
