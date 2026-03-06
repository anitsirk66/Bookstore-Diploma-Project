using BookstoreProjectData.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProjectCore.Models.Events
{
    public class EventsIndexViewModel
    {

        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DateAndTime { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;

        public string AuthorName { get; set; } = null!;
    }
}
