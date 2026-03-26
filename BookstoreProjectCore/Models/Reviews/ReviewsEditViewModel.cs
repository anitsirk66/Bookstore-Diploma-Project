using BookstoreProjectData.Entities;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Reviews
{
    public class ReviewsEditViewModel
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public DateTime DateAndTime { get; set; }

        public bool IsAnonymous { get; set; }


        public Guid BookId { get; set; }
        public string BookTitle { get; set; } = null!;

        //[Required(ErrorMessage = "This field is required.")]
        //public string UserName { get; set; } = null!;
        //public string UserId { get; set; } = null!;


    }
}
