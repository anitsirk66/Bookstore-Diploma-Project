using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class Publisher
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(200)]
        public string Description { get; set; } = null!;

        public List<Publisher_Book> Publishers_Books { get; set; } = new List<Publisher_Book>();

    }
}
