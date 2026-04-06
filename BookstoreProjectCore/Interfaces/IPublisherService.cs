using BookstoreProjectCore.Models.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Interfaces
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublishersIndexViewModel>> IndexAsync();
        //Task<PublisherDetailsViewModel?> GetDetailsAsync(Guid id);
        Task CreateAsync(PublishersCreateViewModel model);
        Task DeleteAsync(Guid id);
        Task<PublishersEditViewModel?> GetEditByIdAsync(Guid id);
        Task EditAsync(PublishersEditViewModel model);
    }
}
