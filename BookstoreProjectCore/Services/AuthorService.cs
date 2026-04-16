using BookstoreProjectCore.Contracts;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreProjectCore.Models.Authors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreProjectCore.Services
{
    public class AuthorService : IAuthorService
    {

        private readonly BookstoreContext context;
        public AuthorService(BookstoreContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<AuthorsIndexViewModel>> Index()
        {
            return await context.Authors.Select(b => new AuthorsIndexViewModel
            {
                Id = b.Id,
                FullName = b.FullName,
                Biography = b.Biography,
                Nationality = b.Nationality,
                ImageUrl = b.ImageUrl
            }).ToListAsync();
        }

        public async Task CreateAsync(AuthorsCreateViewModel dto)
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FullName = dto.FullName,
                Biography = dto.Biography,
                Nationality = dto.Nationality,
                ImageUrl = dto.ImageUrl
            };

            await context.Authors.AddAsync(author);
            await context.SaveChangesAsync();
        }
        public async Task EditAsync(AuthorsEditViewModel dto)
        {
            var author = await context.Authors.FindAsync(dto.Id);

            if (author == null)
                throw new ArgumentException("Author not found");

            author.FullName = dto.FullName;
            author.Biography = dto.Biography;
            author.Nationality = dto.Nationality;
            author.ImageUrl = dto.ImageUrl;

            context.Update(author);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var author = await context.Authors.FindAsync(id);

            if (author == null)
                throw new ArgumentException("Author not found");

            bool hasBooks = await context.Books.AnyAsync(b => b.AuthorId == id);
            if (hasBooks == true) throw new Exception("Cannot delete author with existing books.");

            context.Authors.Remove(author);
            await context.SaveChangesAsync();
        }

        public async Task<AuthorsEditViewModel?> GetEditById(Guid id)
        {
            return await context.Authors
           .Where(b => b.Id == id)
           .Select(b => new AuthorsEditViewModel
           {
               Id = b.Id,
               FullName = b.FullName,
               Biography = b.Biography,
               Nationality = b.Nationality,
               ImageUrl = b.ImageUrl
           })
           .FirstOrDefaultAsync();
        }

        public async Task<AuthorDetailsViewModel?> GetDetailsByIdAsync(Guid id)
        {
            return await context.Authors
                .Where(a => a.Id == id)
                .Select(a => new AuthorDetailsViewModel
                {
                    Id = a.Id,
                    FullName = a.FullName,
                    Biography = a.Biography,
                    Nationality = a.Nationality,
                    ImageUrl = a.ImageUrl

                })
                .FirstOrDefaultAsync();
        }
    }
}
