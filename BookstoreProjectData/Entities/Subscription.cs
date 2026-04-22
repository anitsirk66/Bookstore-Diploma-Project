using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public User User { get; set; } = null!; //*

        [Required]
        public string Address { get; set; } = null!;

        public int Month { get; set; }
        public int Year { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(MonthlyBookSelection))]
        public Guid MonthlyBookSelection { get; set; }

        //public DateTime? EndDate { get; set; }
    }
}
