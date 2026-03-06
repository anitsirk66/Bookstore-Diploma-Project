using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Genres
{
    public class GenreDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Desciption { get; set; } = null!;
    }
}
