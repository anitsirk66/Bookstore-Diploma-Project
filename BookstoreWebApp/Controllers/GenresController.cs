using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Authors;
using BookstoreProjectCore.Models.Genres;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreWebApp.Controllers
{
    public class GenresController : Controller
    {
        private readonly IGenreService service;

        public GenresController(IGenreService _service)
        {
            service = _service;
        }
        
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var genres = await service.Index();

            return View(genres);

        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(GenresCreateViewModel model)
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
            var genre = await service.GetEditById(id);
            if (genre == null) { return NotFound(); }

            return View(genre);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(GenresEditViewModel model)
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
    }
}
