using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Books
{
    public class BookSelectionViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = null!;
        public bool IsSelected { get; set; }
    }
}
