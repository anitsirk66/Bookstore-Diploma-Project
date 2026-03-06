using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Publishers
{
    public class PublisherBookDto
    {
        public Guid PublisherId { get; set; }
        public Guid BookId { get; set; }
        public string Language { get; set; } = null!;
    }
}
