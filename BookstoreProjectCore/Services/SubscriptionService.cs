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

        public async Task Subscribe(string userId, string address)
        {
            var user = await context.Users.FindAsync(userId);

            if (user == null)
                throw new ArgumentException("User not found");

            user.Subscription = true;
            user.Address = address;

            await context.SaveChangesAsync();
        }

        public async Task<bool> IsAlreadySubscribed(string userId)
        {
            var now = DateTime.UtcNow;

            return await context.Subscriptions.AnyAsync(s => s.UserId == userId && s.Month == now.Month && s.Year == now.Year);
        }

        public async Task<List<BookSelectionViewModel>> GetAllBooksForSelection()
        {
            return await context.Books
                .Select(b => new BookSelectionViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    IsSelected = b.IsInSubscription
                })
                .ToListAsync();
        }

        public async Task<bool> UpdateSubscriptionBooks(List<BookSelectionViewModel> books)
        {
            var selected = books.Where(b => b.IsSelected).ToList();

            if (selected.Count != 3)
                return false;

            var allBooks = await context.Books.ToListAsync();

            foreach (var book in allBooks)
            {
                book.IsInSubscription = selected.Any(b => b.Id == book.Id);
            }

            await context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BooksIndexViewModel>> GetSubscriptionBooks()
        {
            return await context.Books
                .Where(b => b.IsInSubscription)
                .Select(b => new BooksIndexViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    AuthorName = b.Author.FullName,
                    Price = b.Price,
                    CoverImageUrl = b.CoverImageUrl
                })
                .ToListAsync();
        }
    }
}
