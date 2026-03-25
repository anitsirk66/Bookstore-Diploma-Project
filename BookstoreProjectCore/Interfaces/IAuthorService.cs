using BookstoreProjectCore.Models.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Contracts
{
    
    public interface IAuthorService
    {
        Task<IEnumerable<AuthorsIndexViewModel>> Index();

        Task<AuthorsIndexViewModel?> GetById(Guid id);
        Task<AuthorsEditViewModel?> GetEditById(Guid id);

        Task CreateAsync(AuthorsCreateViewModel dto);

        Task EditAsync(AuthorsEditViewModel dto);

        Task DeleteAsync(Guid id);
    }
}
