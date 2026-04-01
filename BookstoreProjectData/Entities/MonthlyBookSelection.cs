using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{
    public class MonthlyBookSelection 
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        public ICollection<MonthlyBook> MonthlyBooks { get; set; } = new List<MonthlyBook>();

        //public Book Book { get; set; } = null!;
    }
}
