using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Events
{
    public class EventsEditViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime DateAndTime { get; set; }

        public Guid AuthorId { get; set; }
        //public Author Author { get; set; } = null!;

        //public string AuthorName { get; set; } = null!;
    }
}
