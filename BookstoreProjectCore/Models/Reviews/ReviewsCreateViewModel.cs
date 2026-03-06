using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Reviews
{
    public class ReviewsCreateViewModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = null!;
        public Guid BookId { get; set; }

    }
}
