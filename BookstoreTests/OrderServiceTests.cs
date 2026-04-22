using BookstoreProjectCore.Services;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreTests
{
    public class OrderServiceTests
    {
        private BookstoreContext context_;
        private OrderService service;

        [TearDown]
        public void TearDown()
        {
            context_.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context_ = new BookstoreContext(options);
            service = new OrderService(context_);
        }

        [Test]
        public void AddToCart_Should_Throw_When_InvalidBookId()
        {
            Func<Task> act = async () => await service.AddToCart(Guid.Empty, "user1");

            act.Should().ThrowAsync<Exception>()
                .WithMessage("Invalid book Id");
        }

        [Test]
        public void AddToCart_Should_Throw_When_BookNotFound()
        {
            Func<Task> act = async () => await service.AddToCart(Guid.NewGuid(), "user1");

            act.Should().ThrowAsync<Exception>()
                .WithMessage("Book not found");
        }

        [Test]
        public async Task AddToCart_Should_CreateOrder_When_NotExists()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Old2",
                Synopsis = "synopsiis",
                CoverImageUrl = "htttps.",
                Price = 20,
                IsInSubscription = true
            };
            context_.Books.Add(book);
            await context_.SaveChangesAsync();

            await service.AddToCart(book.Id, "user1");

            context_.Orders.Should().HaveCount(1);
            context_.Orders_Books.Should().HaveCount(1);
        }

        [Test]
        public async Task AddToCart_Should_IncreaseQuantity_When_BookExists()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Old2",
                Synopsis = "synopsiis",
                CoverImageUrl = "htttps.",
                Price = 20,
                IsInSubscription = true
            };

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = "user1",
                Status = "InCart",
                Address="ulica",
                DateAndTime= DateTime.Now,
                Orders_Books = new List<Order_Book>
                {

                    new Order_Book
                    {
                        BookId = book.Id,
                        Quantity = 1,
                        UnitPrice = 10
                    }
                }
            };

            context_.Books.Add(book);
            context_.Orders.Add(order);
            await context_.SaveChangesAsync();

            await service.AddToCart(book.Id, "user1");

            var item = context_.Orders_Books.First();
            item.Quantity.Should().Be(2);
        }

        [Test]
        public async Task GetCart_Should_ReturnCart()
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = "user1",
                Status = "InCart",
                Address = "ulica",
                DateAndTime = DateTime.Now
            };

            context_.Orders.Add(order);
            await context_.SaveChangesAsync();

            var result = await service.GetCart("user1");

            result.Should().NotBeNull();
        }

        [Test]
        public void RemoveFromCart_Should_Throw_When_NoCart()
        {
            Func<Task> act = async () => await service.RemoveFromCart(Guid.NewGuid(), "user1");

            act.Should().ThrowAsync<Exception>()
                .WithMessage("Cart not found");
        }

        [Test]
        public void RemoveFromCart_Should_Throw_When_BookNotInCart()
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = "user1",
                Status = "InCart",
                Address = "bukv",
                DateAndTime = DateTime.Now,
                Orders_Books = new List<Order_Book>()
            };

            context_.Orders.Add(order);
            context_.SaveChanges();

            Func<Task> act = async () => await service.RemoveFromCart(Guid.NewGuid(), "user1");

            act.Should().ThrowAsync<Exception>()
                .WithMessage("Book is not in cart");
        }

        [Test]
        public async Task RemoveFromCart_Should_RemoveItem()
        {
            var bookId = Guid.NewGuid();

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = "user1",
                Status = "InCart",
                Address="fjoe",
                DateAndTime = DateTime.Now,
                Orders_Books = new List<Order_Book>
                {
                    new Order_Book { BookId = bookId, UnitPrice=19, Quantity=1 }
                }
            };

            context_.Orders.Add(order);
            await context_.SaveChangesAsync();

            await service.RemoveFromCart(bookId, "user1");

            context_.Orders_Books.Should().BeEmpty();
        }

        [Test]
        public void ChangeQuantity_Should_Throw_When_NotFound()
        {
            Func<Task> act = async () => await service.ChangeQuantity("user", Guid.NewGuid(), 5);

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task ChangeQuantity_Should_UpdateQuantity()
        {
            var bookId = Guid.NewGuid();

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = "user",
                Status = "InCart",
                Address= "ehuwg",
                DateAndTime = DateTime.Now,
                Orders_Books = new List<Order_Book>
        {
            new Order_Book { BookId = bookId, Quantity = 1,UnitPrice=14 }
        }
            };

            context_.Orders.Add(order);
            await context_.SaveChangesAsync();

            await service.ChangeQuantity("user", bookId, 5);

            context_.Orders_Books.First().Quantity.Should().Be(5);
        }

        [Test]
        public void PlaceOrder_Should_Throw_When_EmptyCart()
        {
            Func<Task> act = async () => await service.PlaceOrder("user", "address");

            act.Should().ThrowAsync<Exception>()
                .WithMessage("Cart is empty.");
        }

        [Test]
        public async Task PlaceOrder_Should_UpdateStatus()
        {
             var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = "user",
                Status = "InCart",
                Address= "ehuwg",
                DateAndTime = DateTime.Now,
                Orders_Books = new List<Order_Book>
        {
            new Order_Book { BookId = Guid.NewGuid(), Quantity = 1,UnitPrice=14 }
        }
            };

            context_.Orders.Add(order);
            await context_.SaveChangesAsync();

            var result = await service.PlaceOrder("user", "Sofia");

            var updated = context_.Orders.First();

            updated.Status.Should().Be("Placed");
            updated.Address.Should().Be("Sofia");
            result.Should().Be("Sofia");
        }




    }
}
