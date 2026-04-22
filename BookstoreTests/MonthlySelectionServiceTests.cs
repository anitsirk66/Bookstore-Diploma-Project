using BookstoreProjectCore.Models.Books;
using BookstoreProjectCore.Services;
using BookstoreProjectData.Entities;
using BookstoreProjectData;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookstoreTests
{
    public class MonthlySelectionServiceTests
    {
        private BookstoreContext context_;
        private MonthlySelectionService service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context_ = new BookstoreContext(options);
            service = new MonthlySelectionService(context_);
        }

        [TearDown]
        public void TearDown()
        {
            context_.Dispose();
        }

        [Test]
        public async Task MonthlyBooks_Should_ReturnBooks_ForCurrentMonth()
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FullName = "Author",
                Biography = "bio",
                Nationality = "bg",
                ImageUrl = "img"
            };

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Book1",
                Price = 10,
                CoverImageUrl = "img",
                Author = author,
                Synopsis="s"
            };

            var selection = new MonthlyBookSelection
            {
                Id = Guid.NewGuid(),
                Month = DateTime.Now.Month,
                Year = DateTime.Now.Year,
                MonthlyBooks = new List<MonthlyBook>
                {
                    new MonthlyBook { Book = book, BookId = book.Id }
                }
            };

            context_.AddRange(author, book, selection);
            await context_.SaveChangesAsync();

            var result = await service.MonthlyBooks();

            result.Should().HaveCount(1);
        }

        [Test]
        public void CreateMonthlySelection_Should_Throw_When_Not3Books()
        {
            var bookIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid() };

            Func<Task> act = async () => await service.CreateMonthlySelection(bookIds);

            act.Should().ThrowAsync<Exception>()
               .WithMessage("You must select exactly 3 books.");
        }

        [Test]
        public async Task CreateMonthlySelection_Should_Throw_When_AlreadyExists()
        {
            var selection = new MonthlyBookSelection
            {
                Id = Guid.NewGuid(),
                Month = DateTime.UtcNow.Month,
                Year = DateTime.UtcNow.Year
            };

            context_.MonthlyBookSelections.Add(selection);
            await context_.SaveChangesAsync();

            var bookIds = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() };

            Func<Task> act = async () => await service.CreateMonthlySelection(bookIds);

            act.Should().ThrowAsync<Exception>().WithMessage("Already created for this month.");
        }

        [Test]
        public async Task CreateMonthlySelection_Should_Create_When_Valid()
        {
            var bookIds = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            await service.CreateMonthlySelection(bookIds);

            context_.MonthlyBookSelections.Should().HaveCount(1);
            context_.MonthlyBooks.Should().HaveCount(3);
        }

        [Test]
        public void GetSubscriptionPrice_Should_Return_DiscountedPrice()
        {
            var books = new List<BooksIndexViewModel>
            {
                new BooksIndexViewModel { Price = 10 },
                new BooksIndexViewModel { Price = 20 }
            };

            var result = service.GetSubscriptionPrice(books);

            result.Should().Be(24);
        }
    }
}
