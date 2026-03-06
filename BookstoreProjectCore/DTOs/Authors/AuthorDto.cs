using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Authors
{
    //BookDto служи и за: Index, Details, API response
    public class AuthorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string Nationality { get; set; } = null!;
    }
}
