using BookstoreProjectCore.Contracts;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreProjectCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly BookstoreContext context;
        public OrderService(BookstoreContext _context)
        {
            context = _context;
        }
        public async Task AddToCart(Guid bookId, string userId)
        {
            var order = await context.Orders.Include(o=>o.Orders_Books).FirstOrDefaultAsync(o=>o.UserId == userId);
            if (order == null)
            {
                order = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    DateAndTime = DateTime.Now
                };
                context.Orders.Add(order);
            }
            var existing = order.Orders_Books.FirstOrDefault(b => b.BookId == bookId);
            if(existing != null)
            {
                existing.Quantity = existing.Quantity+1;
            }
            else
            {
                order.Orders_Books.Add(new Order_Book
                {
                    OrderId = order.Id,
                    BookId = bookId,
                    Quantity = 1
                });
            }
            await context.SaveChangesAsync();
        }
    }
}
