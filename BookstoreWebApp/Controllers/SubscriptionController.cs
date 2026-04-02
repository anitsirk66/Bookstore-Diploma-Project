using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Subscription;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
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
        public  async Task< IActionResult> Index(SubscriptionViewModel vmodel)
        {
            if (!ModelState.IsValid) { return View(vmodel); }

            var user = await manager.GetUserAsync(User);
            if (user == null) { return Unauthorized(); }

            await service.Subscribe(user.Id, vmodel.Address);

            return RedirectToAction("MonthlyBooks");
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(string address)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await service.Subscribe(userId, address);
            TempData["Success"] = "You are now subscribed!";

            return RedirectToAction("Index");
        }

    }
}
