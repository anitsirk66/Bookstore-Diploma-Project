using BookstoreProjectCore.Models.Events;
using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<EventsIndexViewModel>> Index();

        Task<EventsIndexViewModel?> GetById(Guid id);
        Task<EventsEditViewModel?> GetEditById(Guid id);

        Task CreateAsync(EventsCreateViewModel dto);

        Task EditAsync(EventsEditViewModel dto);

        Task DeleteAsync(Guid id);
        Task<List<Author>> GetAuthors();
    }
}
