using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectData.Entities
{

    public class Order
    {
        [Key]

        public Guid Id { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } = null!;

        [ForeignKey(nameof(User))]
        [Required]
        public string UserId { get; set; } = null!;
        public User User { get; set; }

        public List<Order_Book> Orders_Books { get; set; } = new List<Order_Book>();
    }
}
