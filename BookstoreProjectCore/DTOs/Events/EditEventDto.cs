using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Events
{
    public class EditEventDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateAndTime { get; set; }
        public Guid AuthorId { get; set; }
    }
}
