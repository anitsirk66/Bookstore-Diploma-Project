using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Books
{
    public class EditSubscriptionBooksViewModel
    {
        public List<BookSelectionViewModel> Books { get; set; } = new List<BookSelectionViewModel>();
    }
}
