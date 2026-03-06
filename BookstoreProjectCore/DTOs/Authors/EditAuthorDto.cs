using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Authors
{
    public class EditAuthorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Biography { get; set; } = null!;
        public string Nationality { get; set; } = null!;
    }
}
