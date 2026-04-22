using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Services;
using BookstoreWebApp.Models;
using BookstoreWebApp.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookstoreWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISubscriptionService service;

        public HomeController(ILogger<HomeController> logger, ISubscriptionService _service)
        {
            _logger = logger;
            this.service = _service;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeIndexViewModel
            {
                SubscriptionBooks = await service.GetSubscriptionBooks()
            };

            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(Guid id)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
