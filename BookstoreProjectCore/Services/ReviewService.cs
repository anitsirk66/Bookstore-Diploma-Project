using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Reviews;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreWebApp.Models.Reviews;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Services
{
    public class ReviewService:IReviewService
    {
        private readonly BookstoreContext context;
        public ReviewService(BookstoreContext _context)
        {
            context = _context;
        }

        public async Task AddReview(string userId, ReviewsCreateViewModel model)
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                BookId = model.BookId,
                UserId = userId,
                Text = model.Text,
                DateAndTime = DateTime.UtcNow
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewsIndexViewModel>> GetReviews(Guid bookId)
        {
            return await context.Reviews
                .Where(r => r.BookId == bookId)
                .OrderByDescending(r => r.DateAndTime)
                .Select(r => new ReviewsIndexViewModel
                {
                    Username = r.User.UserName,
                    Text = r.Text,
                    DateAndTime = r.DateAndTime
                })
                .ToListAsync();
        }

        public async Task<bool> UserAlreadyReviewed(Guid bookId, string userId)
        {
            return await context.Reviews
                .AnyAsync(r => r.BookId == bookId && r.UserId == userId);
        }
    }
}
