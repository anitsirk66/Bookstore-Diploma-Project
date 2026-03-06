using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Books
{
    public class EditBookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public string Synopsis { get; set; } = null!;
        public decimal Price { get; set; }
        public string CoverImageUrl { get; set; } = null!;

        public Guid AuthorId { get; set; }
        public Guid GenreId { get; set; }
    }
}
