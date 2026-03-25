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
            if (bookId == Guid.Empty)
            {
                throw new Exception("Invalid book Id");
            }

            var book = await context.Books.FirstOrDefaultAsync(b => b.Id == bookId);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            var order = await context.Orders
                .Include(o => o.Orders_Books)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "InCart");

            if (order == null)
            {
                order = new Order
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    DateAndTime = DateTime.Now,
                    Address = "Pending",
                    Status = "InCart"
                };

                context.Orders.Add(order);
            }

            var existingBookOrder = order.Orders_Books
                .FirstOrDefault(b => b.BookId == bookId);

            if (existingBookOrder != null)
            {
                existingBookOrder.Quantity += 1;
            }
            else
            {
                order.Orders_Books.Add(new Order_Book
                {
                    OrderId = order.Id,
                    BookId = bookId,
                    Quantity = 1,
                    UnitPrice = book.Price
                });
            }

            await context.SaveChangesAsync();
        }

        public async Task<Order?> GetCart(string userId)
        {
            return await context.Orders
                .Include(o => o.Orders_Books)
                .ThenInclude(ob => ob.Book)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "InCart");
        }

        public async Task RemoveFromCart(Guid bookId, string userId)
        {
            var order = await context.Orders
                .Include(o => o.Orders_Books)
                .FirstOrDefaultAsync(o => o.UserId == userId && o.Status == "InCart");

            if (order == null)
            {
                throw new Exception("Cart not found");
            }

            var item = order.Orders_Books.FirstOrDefault(ob => ob.BookId == bookId);

            if (item == null)
            {
                throw new Exception("Book is not in cart");
            }

            context.Orders_Books.Remove(item);

            await context.SaveChangesAsync();
        }
    }
}
