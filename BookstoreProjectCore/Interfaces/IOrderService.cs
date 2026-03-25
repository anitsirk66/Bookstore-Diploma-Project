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
<<<<<<< HEAD:BookstoreProjectCore/Interfaces/IOrderService.cs
        Task RemoveFromCart(Guid bookId, string userId);
    }
=======
		Task RemoveFromCart(Guid bookId, string userId);
	}
>>>>>>> 2e8c9ef4dc2c8dfbbaeb6450faaa5f967d37f6d4:BookstoreProjectCore/Contracts/IOrderService.cs
}
