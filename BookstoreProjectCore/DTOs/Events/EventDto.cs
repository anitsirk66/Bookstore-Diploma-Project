using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Events
{
    public class EventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateAndTime { get; set; }
        public string AuthorName { get; set; } = null!;
    }
}
