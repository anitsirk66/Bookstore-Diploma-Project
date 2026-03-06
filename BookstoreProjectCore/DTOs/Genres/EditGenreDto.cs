using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Genres
{
    public class EditGenreDto
    {
        public string Name { get; set; } = null!;
        public string Desciption { get; set; } = null!;
    }
}
