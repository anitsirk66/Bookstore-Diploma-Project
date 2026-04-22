using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Reviews;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreWebApp.Models.Reviews;
using Microsoft.AspNetCore.Http.HttpResults;
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
                DateAndTime = DateTime.UtcNow,
                IsAnonymous = model.IsAnonymous
            };

            context.Reviews.Add(review);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReviewsIndexViewModel>> GetReviews(Guid bookId)
        {
            var reviews = await context.Reviews
                .Where(r => r.BookId == bookId)
                .OrderByDescending(r => r.DateAndTime)
                .Select(r => new ReviewsIndexViewModel
                {
                    Username = r.User.UserName,
                    Text = r.Text,
                    CreatedOn = r.DateAndTime,
                    IsAnonymous = r.IsAnonymous
                })
                .ToListAsync();

            foreach (var review in reviews)
            {
                if (review.IsAnonymous)
                {
                    review.Username = "Anonymous User";
                }
            }
            return reviews;
        }

        public async Task<bool> UserAlreadyReviewed(Guid bookId, string userId)
        {
            return await context.Reviews
                .AnyAsync(r => r.BookId == bookId && r.UserId == userId);
        }


        public async Task DeleteAsync(Guid reviewId, string userId, bool isAdmin)
        {
            if (reviewId == Guid.Empty)
            {
                throw new Exception("ReviewId is EMPTY");
            }

            var review = await context.Reviews
                .FirstOrDefaultAsync(r => r.Id == reviewId);

            if (review == null)
                throw new ArgumentException($"Review not found with id {reviewId}");

            if (!isAdmin && review.UserId != userId)
                throw new UnauthorizedAccessException();

            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
        }

        public async Task EditAsync(ReviewsEditViewModel model, string userId, bool isAdmin)
        {
            var review = await context.Reviews.FirstOrDefaultAsync(r => r.Id == model.Id);

            if (review == null) { throw new ArgumentException("Review not found"); }

            if (!isAdmin && review.UserId != userId)
                throw new UnauthorizedAccessException();

            review.Text = model.Text;
            review.DateAndTime = DateTime.UtcNow;

            await context.SaveChangesAsync();
        }

        public async Task<ReviewsEditViewModel?> GetByIdAsync(Guid reviewId)
        {
            return await context.Reviews.Where(r=>r.Id== reviewId).Select(s=>new ReviewsEditViewModel
            {
                Id=s.Id,
                Text =s.Text,
                IsAnonymous = s.IsAnonymous,
                BookId = s.BookId
            }).FirstOrDefaultAsync();
            
        }


    }
}
