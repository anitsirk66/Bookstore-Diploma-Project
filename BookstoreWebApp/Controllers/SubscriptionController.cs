using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Books;
using BookstoreProjectCore.Models.Subscription;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookstoreWebApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService service;
        private readonly IMonthlySelectionService monthlyService;
        private readonly UserManager<User> manager;

        public SubscriptionController(ISubscriptionService _service, UserManager<User> _manager, IMonthlySelectionService _monthlyService)
        {
            this.service = _service;
            manager = _manager;
            monthlyService = _monthlyService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var books = await service.GetSubscriptionBooks();
            return View(books);
        }


        [Authorize(Roles = "Client")]
        [HttpGet]
        public async Task<IActionResult> Subscribe()
        {
            var user = await manager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            if (await service.IsAlreadySubscribed(user.Id))
            {
                TempData["Fail"] = "You are already subscribed!";
                return RedirectToAction("Index");
            }

            if (!string.IsNullOrEmpty(user.Address))
            {
                await service.Subscribe(user.Id, user.Address);

                TempData["Success"] =
                    $"You are now subscribed! Our top 3 books will arrive at your doorstep, on this address: {user.Address}.";

                return RedirectToAction("Index");
            }

            return View(new SubscriptionViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscriptionViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var user = await manager.GetUserAsync(User);
            if(user == null) { return Unauthorized(); }

            if (await service.IsAlreadySubscribed(user.Id))
            {
                TempData["Fail"] = "You are already subscribed!";
                return RedirectToAction("Index");
            }

            await service.Subscribe(user.Id, model.Address);
            TempData["Success"] = "You are now subscribed!";

            return RedirectToAction("Index");  
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditBooks()
        {
            var books = await service.GetAllBooksForSelection();

            var model = new EditSubscriptionBooksViewModel
            {
                Books = books
            };

            return View("EditBooks", model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditBooks(EditSubscriptionBooksViewModel model)
        {
            var success = await service.UpdateSubscriptionBooks(model.Books);

            if (!success)
            {
                ModelState.AddModelError("", "You must select exactly 3 books.");
                return View(model);
            }

            TempData["Success"] = "Subscription books updated!";
            return RedirectToAction("Index", "Home");
        }
    }
}

