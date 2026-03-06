using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.DTOs.Orders
{
    public class CreateOrderDto
    {
        public Guid UserId { get; set; }
        public List<Guid> BookIds { get; set; } = new();
    }
}
