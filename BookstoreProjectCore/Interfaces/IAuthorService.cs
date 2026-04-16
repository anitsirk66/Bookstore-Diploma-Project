using BookstoreProjectCore.Models.Authors;
using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//MOE

namespace BookstoreProjectCore.Contracts
{
    
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorsIndexViewModel>> Index();

        Task<AuthorsEditViewModel?> GetEditById(Guid id);

        Task CreateAsync(AuthorsCreateViewModel dto);

        Task EditAsync(AuthorsEditViewModel dto);

        Task DeleteAsync(Guid id);

        Task<AuthorDetailsViewModel?> GetDetailsByIdAsync(Guid id);
    }
}
