using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Books;
using BookstoreProjectCore.Models.Reviews;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace BookstoreWebApp.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly UserManager<User> userManager;
        public ReviewsController(IReviewService _reviewService, UserManager<User> _userManager)
        {
            reviewService = _reviewService;
            userManager = _userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [Authorize(Roles = "Client")]
        [HttpPost]
        public async Task<IActionResult> Create(ReviewsCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Details", "Books", new { id = model.BookId });
            }

            var user = await userManager.GetUserAsync(User);
            var userid = user.Id;


            if (await reviewService.UserAlreadyReviewed(model.BookId, userid))
            {
                TempData["Error"] = "You have already reviewed this book.";
                return RedirectToAction("Details", "Books", new { id = model.BookId });
            }

            string username;

            if (model.IsAnonymous)
            {
                username = "Anonymous";
            }
            else
            {
                username = user.UserName;
            }

            await reviewService.AddReview(userid, model);
            return RedirectToAction("Details", "Books", new { id = model.BookId });
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid reviewId)
        {
            //var user = await userManager.GetUserAsync(User);

            //if (user == null) { return Unauthorized(); }

            await reviewService.DeleteAsync(reviewId);

            return RedirectToAction("Details");
        }
    }
}
