using BookstoreProjectCore.Contracts;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreProjectCore.Models.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookstoreProjectCore.Services
{
    public class EventService: IEventService
    {
        private readonly BookstoreContext context;
        public EventService(BookstoreContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<EventsIndexViewModel>> Index()
        {
            return await context.Events.Select(b => new EventsIndexViewModel
            {
                Id = b.Id,
                Name = b.Name,
                DateAndTime = b.DateAndTime,
                AuthorName = b.Author.FullName
            }).ToListAsync();
        }
        public async Task<EventsIndexViewModel?> GetById(Guid id)
        {
            return await context.Events
            .Where(b => b.Id == id)
            .Select(b => new EventsIndexViewModel
            {
                Id = b.Id,
                Name = b.Name,
                DateAndTime = b.DateAndTime,
                AuthorName = b.Author.FullName
            })
            .FirstOrDefaultAsync();

        }
        public async Task CreateAsync(EventsCreateViewModel dto)
        {
            var eventt = new Event
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                DateAndTime = dto.DateAndTime,
                AuthorId = dto.AuthorId
            };

            await context.Events.AddAsync(eventt);
            await context.SaveChangesAsync();
        }
        public async Task EditAsync(EventsEditViewModel dto)
        {
            var eventt = await context.Events.FindAsync(dto.Id);

            if (eventt == null)
                throw new ArgumentException("Event not found");

            eventt.Name = dto.Name;
            eventt.DateAndTime = dto.DateAndTime;
            eventt.AuthorId = dto.AuthorId;

            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var eventt = await context.Events.FindAsync(id);

            if (eventt == null)
                throw new ArgumentException("Event not found");

            context.Events.Remove(eventt);
            await context.SaveChangesAsync();
        }
        public async Task<List<Author>> GetAuthors()
        {
            return await context.Authors
                                .OrderBy(a => a.Id)
                                .ToListAsync();
        }

        public async Task<EventsEditViewModel?> GetEditById(Guid id)
        {
            return await context.Events
            .Where(b => b.Id == id)
            .Select(b => new EventsEditViewModel
            {
                Id = b.Id,
                Name = b.Name,
                DateAndTime = b.DateAndTime,
                //AuthorName = b.Author.FullName
            })
            .FirstOrDefaultAsync();
        }
    }
}
