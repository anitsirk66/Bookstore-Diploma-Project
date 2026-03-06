using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Reviews
{
    public class CreateReviewDto
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        //public int Rating { get; set; }
        public string Text { get; set; } = null!;
        public DateTime DateAndTime { get; set; }

       
    }
}
