using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreProjectCore.Models.Events
{
    public class EventsCreateViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "The event's name can be a maximum of 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [Url(ErrorMessage = "Please enter a valid URL (e.g. https://example.com)")]
        public string Link { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.DateTime, ErrorMessage = "Enter a date and time.")]
        public DateTime DateAndTime { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public Guid AuthorId { get; set; }
        //public Author Author { get; set; } = null!;
    }
}
