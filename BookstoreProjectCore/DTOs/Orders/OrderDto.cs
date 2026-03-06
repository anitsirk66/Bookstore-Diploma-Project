using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Orders
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string Address { get; set; } = null!;
        public string Status { get; set; } = null!;

        public string UserEmail { get; set; } = null!;
        public List<OrderBookDto> Books { get; set; } = new();

    }
}
