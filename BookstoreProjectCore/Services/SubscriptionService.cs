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
    }
}
