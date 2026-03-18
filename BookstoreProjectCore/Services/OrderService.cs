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
            if(bookId == Guid.Empty)
            {
                throw new Exception("Invalid book Id");
            }
            var existingBook = await context.Books.AnyAsync(b => b.Id == bookId);
            if(!existingBook)
            {
                throw new Exception("Book not found");
            }
            var order = await context.Orders.Include(o=>o.Orders_Books).FirstOrDefaultAsync(o=>o.UserId == userId);

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
                await context.SaveChangesAsync();
            }

            var existingBookOrder = order.Orders_Books.FirstOrDefault(b => b.BookId == bookId);

            if(existingBookOrder != null)
            {
                existingBookOrder.Quantity = existingBookOrder.Quantity+1;
            }
            else
            {
                order.Orders_Books.Add(new Order_Book
                {
                    BookId = bookId,
                    Quantity = 1
                });
            }
            await context.SaveChangesAsync();
        }
        public async Task<Order?> GetCart(string userId)
        {
            return await context.Orders
                .Include(o => o.Orders_Books)
                .ThenInclude(ob => ob.Book)
                .FirstOrDefaultAsync(o => o.UserId == userId);
        }

        //public async Task<Order?> GetBooks(string userId)
        //{
        //    return await context.Books
        //        .Include(o => o.Orders_Books)
        //        .ThenInclude(ob => ob.Order)
        //        .FirstOrDefaultAsync(o => o.UserId == userId);
        //}
    }
}
