using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Authors
{
    public class AuthorDetailsViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }

    }
}
