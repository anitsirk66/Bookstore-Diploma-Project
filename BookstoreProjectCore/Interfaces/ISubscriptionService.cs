using BookstoreProjectCore.Models.Books;
using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Interfaces
{
    public interface ISubscriptionService
    {
        Task Subscribe(string userId);

        Task<List<BooksIndexViewModel>> GetMonthlyBooks();
    }
}
