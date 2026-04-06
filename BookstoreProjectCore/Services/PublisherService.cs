using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Publishers;
using BookstoreProjectData.Entities;
using BookstoreProjectData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BookstoreProjectCore.Services
{
    public class PublisherService : IPublisherService
    {

        private readonly BookstoreContext context;

        public PublisherService(BookstoreContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<PublishersIndexViewModel>> IndexAsync()
        {
            return await context.Publishers
                .Select(p => new PublishersIndexViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                })
                .ToListAsync();
        }

        //public async Task<PublisherDetailsViewModel?> GetDetailsAsync(Guid id)
        //{
        //    return await context.Publishers
        //        .Where(p => p.Id == id)
        //        .Select(p => new PublisherDetailsViewModel
        //        {
        //            Id = p.Id,
        //            Name = p.Name,
        //            Description = p.Description,
        //            Books = p.PublisherBooks
        //                .Select(pb => pb.Book.Title)
        //                .ToList()
        //        })
        //        .FirstOrDefaultAsync();
        //}

        public async Task CreateAsync(PublishersCreateViewModel model)
        {
            var publisher = new Publisher
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description
            };

            await context.Publishers.AddAsync(publisher);

            foreach (var bookId in model.SelectedBookIds)
            {
                context.Set<Publisher_Book>().Add(new Publisher_Book
                {
                    PublisherId = publisher.Id,
                    BookId = bookId
                });
            }

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var publisher = await context.Publishers
                .Include(p => p.Publishers_Books)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (publisher == null)
                throw new ArgumentException("Publisher not found");

            context.RemoveRange(publisher.Publishers_Books);

            context.Publishers.Remove(publisher);

            await context.SaveChangesAsync();
        }

        public async Task<PublishersEditViewModel?> GetEditByIdAsync(Guid id)
        {
            return await context.Publishers
                .Where(p => p.Id == id)
                .Select(p => new PublishersEditViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    SelectedBookIds = p.Publishers_Books
                        .Select(pb => pb.BookId)
                        .ToList()
                })
                .FirstOrDefaultAsync();
        }
        public async Task EditAsync(PublishersEditViewModel model)
        {
            var publisher = await context.Publishers
                .Include(p => p.Publishers_Books)
                .FirstOrDefaultAsync(p => p.Id == model.Id);

            if (publisher == null)
                throw new ArgumentException("Publisher not found");

            publisher.Name = model.Name;
            publisher.Description = model.Description;

            context.RemoveRange(publisher.Publishers_Books);

            publisher.Publishers_Books = model.SelectedBookIds
                .Select(bookId => new Publisher_Book
                {
                    PublisherId = publisher.Id,
                    BookId = bookId
                })
                .ToList();

            await context.SaveChangesAsync();
        }
    }
}
