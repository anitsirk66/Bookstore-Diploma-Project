using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Promotions
{
    public class PromotionDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; } = null!;
        public int DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
