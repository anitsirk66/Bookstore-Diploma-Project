using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string FullName { get; set; } = null!;

        [Required]
        [StringLength(1000)]
        public string Biography { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Nationality { get; set; } = null!;

        [Required]
        public string CoverImageUrl { get; set; } = null!;

        public List<Book> Books { get; set;} = new List<Book>();
        public List<Event> Events { get; set;} = new List<Event>();

        //photo
    }
}
