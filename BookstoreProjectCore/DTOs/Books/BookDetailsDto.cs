using BookstoreProjectCore.DTOs.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Books
{
    public class BookDetailsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public string CoverImageUrl { get; set; } = null!;
        public decimal Price { get; set; }

        public string? Synopsis { get; set; }
        public string GenreName { get; set; } = null!;
        public string PublisherName { get; set; } = null!;


        public decimal? DiscountPercentage { get; set; }

        public List<ReviewDto> Reviews { get; set; } = new();
    }
}
