using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class Subscription
    {
        [Key] 
        public Guid Id { get; set; }

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        public int Month { get; set; }
        public int Year { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        //public DateTime? EndDate { get; set; }
    }
}
