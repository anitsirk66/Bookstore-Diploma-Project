using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Authors;
using BookstoreProjectData.Entities;
using BookstoreProjectData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreProjectCore.Models.Genres;
using Microsoft.EntityFrameworkCore;

namespace BookstoreProjectCore.Services
{
    public class GenreService: IGenreService
    {
        private readonly BookstoreContext context;
        public GenreService(BookstoreContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<GenresIndexViewModel>> Index()
        {
            return await context.Genres.Select(b => new GenresIndexViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Desciption = b.Desciption
            }).ToListAsync();
        }

        public async Task CreateAsync(GenresCreateViewModel model)
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Desciption = model.Desciption
            };

            await context.Genres.AddAsync(genre);
            await context.SaveChangesAsync();
        }
        public async Task EditAsync(GenresEditViewModel model)
        {
            var genre = await context.Genres.FindAsync(model.Id);

            if (genre == null)
                throw new ArgumentException("Genre not found");

            genre.Name = model.Name;
            genre.Desciption = model.Desciption;

            context.Update(genre);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var genre = await context.Genres.FindAsync(id);

            if (genre == null)
                throw new ArgumentException("Genre not found");

            bool hasBooks = await context.Books.AnyAsync(b => b.GenreId == id);
            if (hasBooks == true) throw new Exception("Cannot delete genre with existing books.");

            context.Genres.Remove(genre);
            await context.SaveChangesAsync();
        }

        public async Task<GenresEditViewModel?> GetEditById(Guid id)
        {
            return await context.Genres
           .Where(b => b.Id == id)
           .Select(b => new GenresEditViewModel
           {
               Id = b.Id,
               Name = b.Name,
               Desciption = b.Desciption
           })
           .FirstOrDefaultAsync();
        }
    }
}
