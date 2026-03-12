using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Events
{
    public class EventsEditViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "The event's name can be a maximum of 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Enter a date and time.")]
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public Guid AuthorId { get; set; }
        //public Author Author { get; set; } = null!;

        //public string AuthorName { get; set; } = null!;
    }
}
