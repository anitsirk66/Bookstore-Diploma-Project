using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Publishers;
using BookstoreProjectData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookstoreWebApp.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublisherService service;
        private readonly BookstoreContext context;

        public PublishersController(IPublisherService _service, BookstoreContext _context)
        {
            service = _service;
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var publishers = await service.IndexAsync();
            return View(publishers);
        }

        //[HttpGet]
        //public async Task<IActionResult> Details(Guid id)
        //{
        //    var publisher = await service.GetDetailsAsync(id);

        //    if (publisher == null)
        //        return NotFound();

        //    return View(publisher);
        //}

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ViewBag.Books = await context.Books
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Title
                }).ToListAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PublishersCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await service.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var model = await service.GetEditByIdAsync(id);

            if (model == null)
                return NotFound();

            ViewBag.Books = await context.Books
                .Select(b => new SelectListItem
                {
                    Value = b.Id.ToString(),
                    Text = b.Title
                })
                .ToListAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PublishersEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Books = await context.Books
                    .Select(b => new SelectListItem
                    {
                        Value = b.Id.ToString(),
                        Text = b.Title
                    })
                    .ToListAsync();

                return View(model);
            }

            await service.EditAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
