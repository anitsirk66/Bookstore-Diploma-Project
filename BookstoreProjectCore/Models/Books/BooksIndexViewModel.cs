using BookstoreProjectData.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreProjectCore.Models.Books
{
    public class BooksIndexViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public decimal Price { get; set; }

        public string CoverImageUrl { get; set; } = null!;

        public string AuthorName { get; set; } = null!;
        
        //synopsis
        //genre name
        //promotion percentage
    }
}
