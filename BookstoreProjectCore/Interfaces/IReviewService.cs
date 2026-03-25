using BookstoreProjectCore.Models.Books;
using BookstoreProjectCore.Models.Reviews;
using BookstoreWebApp.Models.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Contracts
{
    public interface IReviewService
    {
        Task AddReview(string userid, ReviewsCreateViewModel model);
        Task<IEnumerable<ReviewsIndexViewModel>> GetReviews(Guid bookid);
        Task<bool> UserAlreadyReviewed(Guid bookid, string userid);

        Task DeleteAsync(Guid reviewId);

        Task EditAsync(ReviewsEditViewModel dto);
    }
}
