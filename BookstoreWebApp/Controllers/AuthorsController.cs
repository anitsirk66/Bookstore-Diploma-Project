using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Authors;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreProjectCore.Models.Books;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookstoreProjectCore.Services;

namespace BookstoreWebApp.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService service;
        public AuthorsController(IAuthorService _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var authors = await service.Index();

            return View(authors);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(AuthorsCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await service.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var author = await service.GetEditById(id);
            if (author == null) { return NotFound(); }

            return View(author);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(AuthorsEditViewModel model)
        {
            if (!ModelState.IsValid)
            {

                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();
                return View(model);
            }

            await service.EditAsync(model);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AuthorPage(Guid id)
        {
            var viewModel = await service.GetDetailsByIdAsync(id);

            if (viewModel == null)
                return NotFound();

            return View(viewModel);
        }
    }
}
