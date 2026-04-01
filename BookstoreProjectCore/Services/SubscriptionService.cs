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
    public class SubscriptionService : ISubscriptionService
    {
        private readonly BookstoreContext context;
        public SubscriptionService(BookstoreContext _context)
        {
            context = _context;
        }

        public async Task Subscribe(string userId)
        {
            var sub = new Subscription
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                IsActive = true,
                StartDate = DateTime.UtcNow
            };

            context.Subscriptions.Add(sub);
            await context.SaveChangesAsync();
        }

        public async Task<List<BooksIndexViewModel>> GetMonthlyBooks()
        {
            var now = DateTime.UtcNow;

            var books =  await context.MonthlyBookSelections
                .Where(m => m.Month == now.Month && m.Year == now.Year)
                .Include(m => m.MonthlyBooks)
                    .ThenInclude(mb => mb.Book)
                        .ThenInclude(b => b.Author)
                .SelectMany(m => m.MonthlyBooks)
                .Select(mb => mb.Book)
                .ToListAsync();

            var output = new List<BooksIndexViewModel>();
            foreach (var book in books)
            {
                var vm = new BooksIndexViewModel {
                    Id =book.Id,
                    Title = book.Title,
                    CoverImageUrl = book.CoverImageUrl,
                    Price = book.Price,
                    AuthorName = book.Author.FullName
                };
                output.Add(vm);
            }
            return output;
            //throw new NotImplementedException();
        }
    }
}
