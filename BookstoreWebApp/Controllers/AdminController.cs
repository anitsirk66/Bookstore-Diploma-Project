using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly IBookService bookservice;
        private readonly IMonthlySelectionService monthlySelectionService;

        public AdminController(IBookService _service, IMonthlySelectionService _month)
        {
            bookservice = _service;
            monthlySelectionService = _month;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var books = await bookservice.Index();
            return View(books);
        }
        [HttpPost]  
        public async Task<IActionResult> Create(List<Guid> bookIds)
        {
            await monthlySelectionService.CreateMonthlySelection(bookIds);
            TempData["Success"] = "Monthly selection created!";
                
            return RedirectToAction("Index");
        }
    }
}
