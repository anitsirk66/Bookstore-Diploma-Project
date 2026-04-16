using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class Book
    {

        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.01", "2000")]
        public decimal Price { get; set; }

        [Required]
        [Url]
        public string CoverImageUrl { get; set; } = null!;

        [Required]
        [MinLength(30), MaxLength(1000)]
        public string Synopsis { get; set; } = null!;


        [ForeignKey(nameof(Author))]
        public Guid AuthorId { get; set; }
        public Author Author { get; set; } = null!;


        [ForeignKey(nameof(Genre))]
        public Guid GenreId { get; set; }
        public Genre Genre { get; set; } = null!;


        //[ForeignKey(nameof(Promotion))]
        //public Guid? PromotionId { get; set; }
        //public Promotion? Promotion { get; set; }


        public List<Order_Book> Orders_Books { get; set; } = new List<Order_Book>();
        public List<Publisher_Book> Publishers_Books { get; set; } = new List<Publisher_Book>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}
