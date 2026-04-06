using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Genres
{
    public class GenresCreateViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(300, ErrorMessage = "The discription can be a maximum of 300 characters.")]
        public string Desciption { get; set; } = null!;
    }
}
