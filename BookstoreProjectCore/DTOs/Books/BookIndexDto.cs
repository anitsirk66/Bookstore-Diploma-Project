using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Books
{
    public class BookIndexDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;
        //public string Synopsis { get; set; } = null!;
        public decimal Price { get; set; }

        public string? CoverImageUrl { get; set; }

        public string AuthorName { get; set; } = null!;
        //public string GenreName { get; set; } = null!;
    }
}
