using BookstoreProjectCore.Interfaces;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApp.Controllers
{
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionService service;
        private readonly UserManager<User> manager;

        public SubscriptionController(ISubscriptionService _service, UserManager<User> _manager)
        {
            this.service = _service;
            manager = _manager;
        }

        [HttpGet]
        public  async Task< IActionResult> MonthlyBooks()
        {
            var user = await manager.GetUserAsync(User);
            if (user == null) { return Unauthorized(); }

            ViewBag.IsSubscribed = user.Subscription;

            var books = await service.GetMonthlyBooks();
            return View(books);
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe()
        {
            var user = await manager.GetUserAsync(User);
            if (user == null) { return Unauthorized(); }

            await service.Subscribe(user.Id);

            return RedirectToAction("MonthlyBooks");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
