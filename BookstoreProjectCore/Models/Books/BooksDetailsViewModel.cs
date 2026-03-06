using BookstoreProjectData.Entities;
using BookstoreWebApp.Models.Reviews;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreProjectCore.Models.Books
{
    public class BooksDetailsViewModel
    {
        public Guid Id { get; set; }

        [StringLength(50)] 
        public string Title { get; set; } = null!;

        [StringLength(1000)]
        public string Synopsis { get; set; } = null!;

        public string GenreName { get; set; } = null!;

        public decimal Price { get; set; }

        public string CoverImageUrl { get; set; } = null!;

        public string AuthorName { get; set; } = null!;
        public decimal PromotionPercent { get; set; }

        //publisher
        public List<ReviewsIndexViewModel> Reviews { get; set; } = new List<ReviewsIndexViewModel>();
    }
}
