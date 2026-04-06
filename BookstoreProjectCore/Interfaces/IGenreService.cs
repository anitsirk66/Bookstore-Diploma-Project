using BookstoreProjectCore.Models.Authors;
using BookstoreProjectCore.Models.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Interfaces
{
    public interface IGenreService
    {
        Task<IEnumerable<GenresIndexViewModel>> Index();

        Task<GenresEditViewModel?> GetEditById(Guid id);

        Task CreateAsync(GenresCreateViewModel model);

        Task EditAsync(GenresEditViewModel model);

        Task DeleteAsync(Guid id);

    }
}
