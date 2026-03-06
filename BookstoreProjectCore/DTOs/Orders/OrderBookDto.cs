using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Orders
{
    public
        class OrderBookDto
    {
        public Guid OrderId { get; set; }
        public Guid BookId { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
