using BookstoreProjectCore.Models.Books;

namespace BookstoreWebApp.Models.Home
{
    public class HomeIndexViewModel
    {
        public IEnumerable<BooksIndexViewModel> SubscriptionBooks { get; set; } 

    }
}
