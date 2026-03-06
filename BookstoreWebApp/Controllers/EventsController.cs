//using AspNetCore;
using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.DTOs.Events;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreProjectCore.Models.Books;
using BookstoreProjectCore.Models.Events;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace BookstoreWebApp.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService service;
        public EventsController(IEventService _service)
        {
            service = _service;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var events = await service.Index();
            
            return View(events);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var authors = await service.GetAuthors();
            ViewBag.Authors = new SelectList(authors, "Id", "FullName");

            return View(); 
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(EventsCreateViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var authors = await service.GetAuthors();
                ViewBag.Authors = new SelectList(authors, "Id", "FullName");

                //var errors = ModelState.Values
                //    .SelectMany(v => v.Errors)
                //    .Select(e => e.ErrorMessage)
                //    .ToList();

                return View(model);
            }

            await service.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var eventt = await service.GetEditById(id);
            if (eventt == null) { return NotFound(); }

            var authors = await service.GetAuthors();
            ViewBag.Authors = new SelectList(authors, "Id", "FullName");


            return View(eventt); 
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EventsEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var authors = await service.GetAuthors();
                ViewBag.Authors = new SelectList(authors, "Id", "FullName");
                return View(model);
            }

            await service.EditAsync(model);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            await service.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost]
        //public async Task<IActionResult> DeletePost (Guid id)
        //{
        //    await service.DeleteAsync(id);
        //    return RedirectToAction("Index");
        //}
    }

} 
