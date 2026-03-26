using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class Review
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Book))]
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;


        [ForeignKey(nameof(User))]
        [Required]
        public string UserId { get; set; } = null!;
        public User User { get; set; } = null!;

        [Required]
        [StringLength(250)]
        public string Text { get; set; } = null!;

        [Required]
        public DateTime DateAndTime { get; set; }

        public bool IsAnonymous { get; set; }
    }
}
