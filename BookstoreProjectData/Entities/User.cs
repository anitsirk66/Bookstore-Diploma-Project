using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookstoreProjectData.Entities
{
    public class User: IdentityUser
    {

        [Required]
        public bool Subscription { get; set; } = false;

        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Review> Reviews { get; set; } = new List<Review>();

        [Required]
        public string Address { get; set; } = null!;
    }
}
