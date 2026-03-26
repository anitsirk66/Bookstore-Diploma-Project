using BookstoreProjectCore.Contracts;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreProjectCore.Models.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookstoreWebApp.Models.Reviews;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookstoreProjectCore.Services
{
    public class BookService : IBookService
    {
        private readonly BookstoreContext context;
        public BookService (BookstoreContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<BooksIndexViewModel>> Index()
        {
            return await context.Books.Select(b => new BooksIndexViewModel
            {
                Id = b.Id,
                Title = b.Title,
                AuthorName = b.Author.FullName,
                CoverImageUrl = b.CoverImageUrl,
                Price = b.Price
            }).ToListAsync();
        }
        public async Task<BooksDetailsViewModel?> ShowBookDetails(Guid id)
        {
            return await context.Books
            .Where(b => b.Id == id)
            .Select(b => new BooksDetailsViewModel
            {
                Id = b.Id,
                Title = b.Title,
                AuthorName = b.Author.FullName,
                CoverImageUrl = b.CoverImageUrl,
                Price = b.Price,
                Synopsis = b.Synopsis,
                GenreName = b.Genre.Name,
                //PromotionPercent = b.Promotion,

                Reviews = b.Reviews.Select(r => new ReviewsIndexViewModel
                {
                    Id = r.Id,
                    Username = r.User.UserName,
                    Text = r.Text,
                    CreatedOn = r.DateAndTime,
                    BookId = r.BookId,
                    IsAnonymous = r.IsAnonymous
                }).ToList()
            })
            .FirstOrDefaultAsync();

        }

        public async Task<BooksIndexViewModel?> GetByIdIndex(Guid id)
        {
            return await context.Books
             .Where(b => b.Id == id)
             .Select(b => new BooksIndexViewModel
             {
                 Id = b.Id,
                 Title = b.Title,
                 AuthorName = b.Author.FullName,
                 CoverImageUrl = b.CoverImageUrl,
                 Price = b.Price,
             })
             .FirstOrDefaultAsync();

        }

        public async Task<BooksEditViewModel?> GetByIdEdit(Guid id)
        {
            return await context.Books
             .Where(b => b.Id == id)
             .Select(b => new BooksEditViewModel
             {
                 Id = b.Id,
                 Title = b.Title,
                 CoverImageUrl = b.CoverImageUrl,
                 Price = b.Price,
                 Synopsis = b.Synopsis,
                 AuthorId = b.AuthorId,
                 GenreId = b.GenreId,
                 AuthorName = b.Author.FullName,
                 GenreName = b.Genre.Name
             })
             .FirstOrDefaultAsync();

        }

        public async Task CreateAsync(BooksCreateViewModel dto)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = dto.Title,
                Price = dto.Price,
                CoverImageUrl = dto.CoverImageUrl,
                Synopsis = dto.Synopsis,
                AuthorId = dto.AuthorId,
                GenreId = dto.GenreId
            };

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
        }
        public async Task EditAsync(BooksEditViewModel dto)
        {
            var book = await context.Books
                .FirstOrDefaultAsync(b => b.Id == dto.Id);

            if (book == null)
                throw new ArgumentException("Book not found");

            book.Title = dto.Title;
            book.Price = dto.Price;
            book.CoverImageUrl = dto.CoverImageUrl;
            book.Synopsis = dto.Synopsis;
            book.AuthorId = dto.AuthorId;
            book.GenreId = dto.GenreId;

            await context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                throw new ArgumentException("Book not found");

            context.Books.Remove(book);
            await context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAuthors()
        {
            return await context.Authors
                                .OrderBy(a => a.Id)
                                .ToListAsync();
        }
        public async Task<List<Genre>> GetGenres()
        {
            return await context.Genres
                                .OrderBy(a => a.Id)
                                .ToListAsync();
        }
        public async Task<List<Promotion>> GetPromotions()
        {
            return await context.Promotions
                                .OrderBy(a => a.Id)
                                .ToListAsync();
        }

        public async Task<List<Publisher>> GetPublishers()
        {
            return await context.Publishers
                                .OrderBy(a => a.Id)
                                .ToListAsync();
        }

        public async Task<IEnumerable<BooksIndexViewModel>> FilterBooks(List<Guid> genreIds, List<Guid> authorIds, List<Guid> publisherIds)
        {
            var query = context.Books.AsQueryable();

            if (genreIds != null && genreIds.Any())
            {
                query = query.Where(b => genreIds.Contains(b.GenreId));
            }

            if (authorIds != null && authorIds.Any())
            {
                query = query.Where(b => authorIds.Contains(b.AuthorId));
            }

            if (publisherIds != null && publisherIds.Any())
            {
                query = query.Where(b => b.Publishers_Books.Any(pb => publisherIds.Contains(pb.PublisherId)));
            }

            return await query.Select(b => new BooksIndexViewModel
            {
                Id = b.Id, Title = b.Title, AuthorName = b.Author.FullName, CoverImageUrl = b.CoverImageUrl, Price = b.Price
            }).ToListAsync();
        }
        
    }
}
