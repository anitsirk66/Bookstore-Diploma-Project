using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Reviews
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        //public int Rating { get; set; }
        public DateTime DateAndTime { get; set; }

        public string Text { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string BookTitle { get; set; } = null!;
        
    }
}
