using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Books;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Services
{
    public class MonthlySelectionService : IMonthlySelectionService
    {
        private readonly BookstoreContext context;
        public MonthlySelectionService (BookstoreContext _cont)
        {
            context = _cont;
        }

        public async Task<List<BooksIndexViewModel>> GetMonthlyBooks()
        {
            var now = DateTime.Now;

            return await context.MonthlyBookSelections
            .Where(m => m.Month == now.Month && m.Year == now.Year)
            .SelectMany(m => m.MonthlyBooks)
            .Select(mb => new BooksIndexViewModel
            {
                Id = mb.Book.Id,
                Title = mb.Book.Title,
                CoverImageUrl = mb.Book.CoverImageUrl,
                Price = mb.Book.Price,
                AuthorName = mb.Book.Author.FullName
            })
            .ToListAsync();
        }

        public async Task CreateMonthlySelection(List<Guid> bookIds)
        {
            if (bookIds.Count != 3)
                throw new Exception("You must select exactly 3 books.");

            var now = DateTime.UtcNow;

            var exists = await context.MonthlyBookSelections
                .AnyAsync(m => m.Month == now.Month && m.Year == now.Year);

            if (exists)
                throw new Exception("Already created for this month.");

            var selection = new MonthlyBookSelection
            {
                Id = Guid.NewGuid(),
                Month = now.Month,
                Year = now.Year,
                MonthlyBooks = bookIds.Select(id => new MonthlyBook
                {
                    BookId = id
                }).ToList()
            };

            context.MonthlyBookSelections.Add(selection);
            await context.SaveChangesAsync();
        }

        public decimal GetSubscriptionPrice(List<BooksIndexViewModel> books)
        {
            var total = books.Sum(p => p.Price);
            return total * 0.8m;
        }
    }
}
