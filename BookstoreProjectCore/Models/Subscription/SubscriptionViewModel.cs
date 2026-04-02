using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Models.Subscription
{
    public class SubscriptionViewModel
    {
        [Required]
        public string Address { get; set; } = null!;
    }
}
