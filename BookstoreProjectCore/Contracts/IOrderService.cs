using BookstoreProjectData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Contracts
{
    public interface IOrderService
    {
        Task AddToCart(Guid bookId, string userId);
        Task<Order?> GetCart(string userId);
    }
}
