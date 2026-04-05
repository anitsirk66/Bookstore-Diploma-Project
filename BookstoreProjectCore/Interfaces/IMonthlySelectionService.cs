using BookstoreProjectCore.Models.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Interfaces
{
    public interface IMonthlySelectionService
    {
        Task<List<BooksIndexViewModel>> MonthlyBooks();

        Task CreateMonthlySelection(List<Guid> bookIds);

        decimal GetSubscriptionPrice(List<BooksIndexViewModel> books);
    }
}
