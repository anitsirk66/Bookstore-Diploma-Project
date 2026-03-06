using System.ComponentModel.DataAnnotations;

namespace BookstoreProjectCore.Models.Authors
{
    public class AuthorsEditViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; } = null!;
        [Required]
        [StringLength(2000)]
        public string Biography { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Nationality { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
