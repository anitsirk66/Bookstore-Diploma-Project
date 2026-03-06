using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{

    public class Genre
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(300)]
        public string Desciption { get; set; } = null!;

        public List<Book> Books { get; set; } = new List<Book>();
    }
}
