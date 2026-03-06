using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class Promotion
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(0, 100)]
        public int Percent {  get; set; } 
        
        [Required]
        [StringLength(200)]
        public string Description { get; set; } = null!;

        [Required]
        public DateOnly From { get; set; }
        [Required]
        public DateOnly To { get; set; }

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
