using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Publishers
{
    public class CreatePublisherDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}

