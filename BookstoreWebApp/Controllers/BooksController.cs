using BookstoreProjectData.Entities;
using BookstoreProjectData;
using BookstoreProjectCore.Models.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookstoreProjectCore.Models.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using BookstoreWebApp.Models.Reviews;
using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Services;
using System.Security.Claims;
using BookstoreProjectCore.Models.Reviews;

namespace BookstoreWebApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService service;
        private readonly IReviewService reviewService;
        public BooksController(IBookService _service, IReviewService _reviewService)
        {
            service = _service;
            reviewService = _reviewService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index(string searchItem, List<Guid> genreIds, List<Guid> authorIds, List<Guid> publisherIds)
        {
            ViewBag.Authors = await service.GetAuthors();

            ViewBag.Genres = await service.GetGenres();

            ViewBag.Publishers = await service.GetPublishers();

            var books = await service.FilterBooks(searchItem, genreIds, authorIds, publisherIds);

            return View(books);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await service.GetAuthors();
            ViewBag.Authors = new SelectList(authors, "Id", "FullName");

            var genres = await service.GetGenres();
            ViewBag.Genres = new SelectList(genres, "Id", "Name");

            //var promotions = await service.GetPromotions();
            //ViewBag.Promotions = new SelectList(promotions, "Id", "Percent");

            return View();  
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(BooksCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Select(x => x.Value.Errors)
                //    .Where(y => y.Count > 0)
                //    .ToList();

                var authors = await service.GetAuthors();
                ViewBag.Authors = new SelectList(authors, "Id", "FullName");

                var genres = await service.GetGenres();
                ViewBag.Genres = new SelectList(genres, "Id", "Name");

                return View(model);
            }

            await service.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var authors = await service.GetAuthors();
            ViewBag.Authors = new SelectList(authors, "Id", "FullName");

            var genres = await service.GetGenres();
            ViewBag.Genres = new SelectList(genres, "Id", "Name");

            var book = await service.GetByIdEdit(id);
            if (book == null) { return NotFound(); }

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(BooksEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //var errors = ModelState.Select(x => x.Value.Errors)
                //    .Where(y => y.Count > 0)
                //    .ToList();
                    
                var authors = await service.GetAuthors();
                ViewBag.Authors = new SelectList(authors, "Id", "FullName", model.AuthorId);

                var genres = await service.GetGenres();
                ViewBag.Genres = new SelectList(genres, "Id", "Name", model.GenreId);

                //var promotions = await service.GetPromotions();
                //ViewBag.Promotions = new SelectList(promotions, "Id", "Percent");

                return View(model);
            }

            await service.EditAsync(model);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var book = await service.ShowBookDetails(id);
            if (book == null) { return NotFound(); };
            return View(book);
        }
    }
}
