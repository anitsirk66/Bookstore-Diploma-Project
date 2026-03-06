using BookstoreProjectData.Entities;
using System.ComponentModel.DataAnnotations;

namespace BookstoreProjectCore.Models.Authors
{
    public class AuthorsIndexViewModel
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string FullName { get; set; } = null!;

        [StringLength(2000)]
        public string Biography { get; set; } = null!;
        [StringLength(50)]

        public string Nationality { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;
    }
}
