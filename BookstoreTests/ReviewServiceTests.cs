using BookstoreProjectCore.Models.Reviews;
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
    public class ReviewServiceTests
    {
        private BookstoreContext context_;
        private ReviewService service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context_ = new BookstoreContext(options);
            service = new ReviewService(context_);
        }

        [TearDown]
        public void TearDown()
        {
            context_.Dispose();
        }

        [Test]
        public async Task AddReview_Should_AddReview()
        {
            var book = new Book { Id = Guid.NewGuid(), Title = "Test", CoverImageUrl = "fnue973", Synopsis="dap", Price=8 };

            context_.Books.Add(book);
            await context_.SaveChangesAsync();

            var model = new ReviewsCreateViewModel
            {
                BookId = book.Id,
                Text = "Great",
                IsAnonymous = false
            };

            await service.AddReview("user1", model);

            context_.Reviews.Should().HaveCount(1);
        }

        [Test]
        public async Task GetReviews_Should_ReturnReviews()
        {
            var user = new User { Id = "user1", UserName = "Ivan", Subscription = false, Address = "new" };

            var bookId = Guid.NewGuid();

            context_.Users.Add(user);

            context_.Reviews.Add(new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test9",
                BookId = bookId,
                DateAndTime = DateTime.Now,
                IsAnonymous = false,
                UserId = user.Id,
                User = user 
            });

            await context_.SaveChangesAsync();

            var result = await service.GetReviews(bookId);

            result.Should().HaveCount(1);
        }

        [Test]
        public async Task GetReviews_Should_ReplaceUsername_When_Anonymous()
        {
            var user = new User { Id = "user1", UserName = "Ivan", Subscription = false, Address = "new" };

            var bookId = Guid.NewGuid();

            context_.Users.Add(user);

            context_.Reviews.Add(new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test",
                BookId = bookId, 
                DateAndTime = DateTime.Now,
                IsAnonymous = true, 
                UserId = user.Id,
                User = user
            });

            await context_.SaveChangesAsync();

            var result = await service.GetReviews(bookId);

            result.First().Username.Should().Be("Anonymous User");
        }

        [Test]
        public async Task UserAlreadyReviewed_Should_ReturnTrue()
        {
            var bookId = Guid.NewGuid();

            context_.Reviews.Add(new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test",
                BookId = bookId,
                DateAndTime = DateTime.Now,
                IsAnonymous = true,
                UserId = "user1" 
            });

            await context_.SaveChangesAsync();

            var result = await service.UserAlreadyReviewed(bookId, "user1");

            result.Should().BeTrue();
        }

        [Test]
        public async Task UserAlreadyReviewed_Should_ReturnFalse()
        {
            var result = await service.UserAlreadyReviewed(Guid.NewGuid(), "user1");

            result.Should().BeFalse();
        }

        [Test]
        public void DeleteAsync_Should_Throw_When_IdEmpty()
        {
            Func<Task> act = async () => await service.DeleteAsync(Guid.Empty, "user", false);

            act.Should().ThrowAsync<Exception>()
                .WithMessage("ReviewId is EMPTY");
        }

        [Test]
        public void DeleteAsync_Should_Throw_When_NotFound()
        {
            Func<Task> act = async () => await service.DeleteAsync(Guid.NewGuid(), "user", false);

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public void DeleteAsync_Should_Throw_When_NotOwner()
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test",
                BookId = Guid.NewGuid(),
                DateAndTime = DateTime.Now,
                IsAnonymous = false,
                UserId = "hui"
            };

            context_.Reviews.Add(review);
            context_.SaveChanges();

            Func<Task> act = async () => await service.DeleteAsync(review.Id, "otherUser", false);

            act.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Test]
        public async Task DeleteAsync_Should_Remove_When_Owner()
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test",
                BookId = Guid.NewGuid(),
                DateAndTime = DateTime.Now,
                IsAnonymous = false,
                UserId = "user1"
            };

            context_.Reviews.Add(review);
            await context_.SaveChangesAsync();

            await service.DeleteAsync(review.Id, "user1", false);

            context_.Reviews.Should().BeEmpty();
        }


        [Test]
        public async Task DeleteAsync_Should_Remove_When_Admin()
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test7",
                BookId = Guid.NewGuid(),
                DateAndTime = DateTime.Now,
                IsAnonymous = true,
                UserId = "ejojfneo"
            };

            context_.Reviews.Add(review);
            await context_.SaveChangesAsync();

            await service.DeleteAsync(review.Id, "other", true);

            context_.Reviews.Should().BeEmpty();
        }

        [Test]
        public void EditAsync_Should_Throw_When_NotFound()
        {
            var model = new ReviewsEditViewModel
            {
                Id = Guid.NewGuid(),
                Text = "Edit"
            };

            Func<Task> act = async () => await service.EditAsync(model, "user", false);

            act.Should().ThrowAsync<ArgumentException>();
        }


        [Test]
        public void EditAsync_Should_Throw_When_NotOwner()
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test5",
                BookId = Guid.NewGuid(),
                DateAndTime = DateTime.Now,
                IsAnonymous = false,
                UserId = "dhoeu998"
            };

            context_.Reviews.Add(review);
            context_.SaveChanges();

            var model = new ReviewsEditViewModel
            {
                Id = review.Id,
                Text = "New"
            };

            Func<Task> act = async () => await service.EditAsync(model, "other", false);

            act.Should().ThrowAsync<UnauthorizedAccessException>();
        }

        [Test]
        public async Task EditAsync_Should_UpdateText()
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test2",
                BookId = Guid.NewGuid(),
                DateAndTime = DateTime.Now,
                IsAnonymous = false,
                UserId = "user1"
            };

            context_.Reviews.Add(review);
            await context_.SaveChangesAsync();

            var model = new ReviewsEditViewModel
            {
                Id = review.Id,
                Text = "New",
                IsAnonymous = true
            };

            await service.EditAsync(model, "user1", false);

            context_.Reviews.First().Text.Should().Be("New");
        }

        [Test]
        public async Task GetByIdAsync_Should_ReturnModel()
        {
            var review = new Review
            {
                Id = Guid.NewGuid(),
                Text = "Test",
                BookId = Guid.NewGuid(),
                DateAndTime = DateTime.Now,
                IsAnonymous = false,
                UserId = "n8yry84"
            };

            context_.Reviews.Add(review);
            await context_.SaveChangesAsync();

            var result = await service.GetByIdAsync(review.Id);

            result.Should().NotBeNull();
            result.Text.Should().Be("Test");
        }


    }
}
