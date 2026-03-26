using BookstoreProjectCore.Models.Books;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<BooksIndexViewModel>> Index();

        Task<BooksDetailsViewModel?> ShowBookDetails(Guid id);

        Task<BooksIndexViewModel?> GetByIdIndex(Guid id);
        Task<BooksEditViewModel?> GetByIdEdit(Guid id);

        Task CreateAsync(BooksCreateViewModel dto);

        Task EditAsync(BooksEditViewModel dto);

        Task DeleteAsync(Guid id);

        Task<List<Author>> GetAuthors();
        Task<List<Genre>> GetGenres();
        Task<List<Promotion>> GetPromotions();

        Task<List<Publisher>> GetPublishers();

        Task<IEnumerable<BooksIndexViewModel>> FilterBooks(string searchItem, List<Guid> genreIds, List<Guid> authorIds, List<Guid> publisherIds);

    }
}

