using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Genres
{
    public class GenresIndexViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, ErrorMessage = "The name can be a maximum of 50 characters.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(300, ErrorMessage = "The discription can be a maximum of 300 characters.")]
        public string Desciption { get; set; } = null!;

    }
}
