using BookstoreProjectCore.Models.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Contracts
{
    //InvalidOperationException: The model item passed into the ViewDataDictionary is of type 'BookstoreProjectCore.Models.Authors.AuthorsCreateViewModel', but this ViewDataDictionary instance requires a model item of type 'BookstoreProjectCore.Models.Authors.AuthorsIndexViewModel'.
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
