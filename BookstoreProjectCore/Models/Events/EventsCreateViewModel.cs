using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookstoreProjectCore.Models.Events
{
    public class EventsCreateViewModel
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DateAndTime { get; set; }

        public Guid AuthorId { get; set; }
        //public Author Author { get; set; } = null!;
    }
}
