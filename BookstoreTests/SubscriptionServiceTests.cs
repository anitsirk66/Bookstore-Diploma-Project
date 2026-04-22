using BookstoreProjectCore.Models.Books;
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
    public class SubscriptionServiceTests
    {
        private BookstoreContext context_;
        private SubscriptionService service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context_ = new BookstoreContext(options);
            service = new SubscriptionService(context_);
        }

        [TearDown]
        public void TearDown()
        {
            context_.Dispose();
        }

        [Test]
        public void Subscribe_Should_Throw_When_UserNotFound()
        {
            Func<Task> act = async () => await service.Subscribe("missing", "Sofia");

            act.Should().ThrowAsync<ArgumentException>()
                .WithMessage("User not found");
        }

        [Test]
        public async Task Subscribe_Should_UpdateUser()
        {
            var user = new User
            {
                Id = "user1",
                UserName = "test",
                Address = "fhrrhu",
                Subscription = false
            };

            context_.Users.Add(user);
            await context_.SaveChangesAsync();

            await service.Subscribe("user1", "Sofia");

            var updated = context_.Users.First();

            updated.Subscription.Should().BeTrue();
            updated.Address.Should().Be("Sofia");
        }

        [Test]
        public async Task IsAlreadySubscribed_Should_ReturnTrue()
        {
            var now = DateTime.UtcNow;

            context_.Subscriptions.Add(new Subscription
            {
                Id = Guid.NewGuid(),
                UserId = "user1",
                Address = "xsdfgh",
                CreatedOn = now,
                Month = now.Month,
                Year = now.Year
            });

            await context_.SaveChangesAsync();

            var result = await service.IsAlreadySubscribed("user1");

            result.Should().BeTrue();
        }

        [Test]
        public async Task IsAlreadySubscribed_Should_ReturnFalse()
        {
            var result = await service.IsAlreadySubscribed("user1");

            result.Should().BeFalse();
        }

        [Test]
        public async Task GetAllBooksForSelection_Should_ReturnBooks()
        {
            context_.Books.AddRange(
                new Book { Id = Guid.NewGuid(), Title = "A", IsInSubscription = true, Price = 12, CoverImageUrl="f", Synopsis= "wheuifb" },
                new Book { Id = Guid.NewGuid(), Title = "B", IsInSubscription = true, Price = 12, CoverImageUrl = "g", Synopsis = "wheuifbfirh" }
            );

            await context_.SaveChangesAsync();

            var result = await service.GetAllBooksForSelection();

            result.Should().HaveCount(2);
        }

        [Test]
        public async Task UpdateSubscriptionBooks_Should_ReturnFalse_When_NotThree()
        {
            var model = new List<BookSelectionViewModel>
            {
                new BookSelectionViewModel { Id = Guid.NewGuid(), IsSelected = true, Title="wkojd" },
                new BookSelectionViewModel { Id = Guid.NewGuid(), IsSelected = true, Title="ieooiw" }
            };

            var result = await service.UpdateSubscriptionBooks(model);

            result.Should().BeFalse();
        }

        [Test]
        public async Task UpdateSubscriptionBooks_Should_UpdateBooks()
        {
            var books = new List<Book>
            {
                new Book { Id = Guid.NewGuid(), Title = "A", IsInSubscription = true, Price = 12, CoverImageUrl="NIEONDO4", Synopsis= "wheuifb" },
                new Book { Id = Guid.NewGuid(), Title = "B", IsInSubscription = false, Price = 16, CoverImageUrl="opw", Synopsis= "po09jri" },
                 new Book { Id = Guid.NewGuid(), Title = "C", IsInSubscription = true, Price = 3, CoverImageUrl="ref", Synopsis= "590u4n" },
                  new Book { Id = Guid.NewGuid(), Title = "D", IsInSubscription = true, Price = 11, CoverImageUrl="pt04", Synopsis= "wheuirfb" }
            };

            context_.Books.AddRange(books);
            await context_.SaveChangesAsync();

            var model = books.Take(3)
                .Select(b => new BookSelectionViewModel
                {
                    Id = b.Id,
                    IsSelected = true,
                    Title="NO man's land"
                }).ToList();

            var result = await service.UpdateSubscriptionBooks(model);

            result.Should().BeTrue();

            var selectedCount = context_.Books.Count(b => b.IsInSubscription);

            selectedCount.Should().Be(3);
        }


        [Test]
        public async Task GetSubscriptionBooks_Should_ReturnOnlySelected()
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FullName = "Author",
                Biography = "bio",
                Nationality = "bg",
                ImageUrl = "img"
            };

            var book1 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                Synopsis = "testche",
                CoverImageUrl = "dje",
                Author = author,
               
                AuthorId = author.Id,
               
                IsInSubscription = true
            };

            var book2 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                Synopsis = "testche",
                CoverImageUrl = "dje",
                Author = author,
                AuthorId = author.Id,
                IsInSubscription = false
            };

            context_.AddRange(author, book1, book2);
            await context_.SaveChangesAsync();

            var result = await service.GetSubscriptionBooks();

            result.Should().HaveCount(1);
        }


    }
}
