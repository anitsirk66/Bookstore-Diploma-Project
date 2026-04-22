using BookstoreProjectCore.Models.Authors;
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
    public class AuthorServiceTests
    {
        private BookstoreContext context_;
        private AuthorService service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context_ = new BookstoreContext(options);
            service = new AuthorService(context_);
        }

        [TearDown]
        public void TearDown()
        {
            context_.Dispose();
        }

        [Test]
        public async Task Index_Should_Return_AllAuthors()
        {
            context_.Authors.AddRange(
               new Author { Id = Guid.NewGuid(), FullName = "A", Nationality = "B", Biography = "C", ImageUrl = "D" },
               new Author { Id = Guid.NewGuid(), FullName = "Aa", Nationality = "Bb", Biography = "Cc", ImageUrl = "dD" }
            );

            await context_.SaveChangesAsync();

            var result = await service.Index();

            result.Should().HaveCount(2);
        }

        [Test]
        public async Task CreateAsync_Should_AddAuthor()
        {
            var dto = new AuthorsCreateViewModel
            {
                FullName = "Test",
                Biography = "Bio",
                Nationality = "BG",
                ImageUrl = "img"
            };

            await service.CreateAsync(dto);

            context_.Authors.Should().HaveCount(1);
        }

        [Test]
        public void EditAsync_Should_Throw_When_NotFound()
        {
            var dto = new AuthorsEditViewModel { Id = Guid.NewGuid() };

            Func<Task> act = async () => await service.EditAsync(dto);

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task DeleteAsync_Should_Throw_When_HasBooks()
        {
            var author = new Author { Id = Guid.NewGuid(), FullName = "A", Nationality="b", Biography="c", ImageUrl="d" };
            var book = new Book { Id = Guid.NewGuid(), AuthorId = author.Id, Title="da", CoverImageUrl="fff", Synopsis="smth", Price=19, IsInSubscription=true };

            context_.AddRange(author, book);
            await context_.SaveChangesAsync();

            Func<Task> act = async () => await service.DeleteAsync(author.Id);

            act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public async Task DeleteAsync_Should_Remove_When_NoBooks()
        {
            var author = new Author { Id = Guid.NewGuid(), FullName = "A", Nationality="B", Biography="C", ImageUrl="D" };

            context_.Authors.Add(author);
            await context_.SaveChangesAsync();

            await service.DeleteAsync(author.Id);

            context_.Authors.Should().BeEmpty();
        }
    }
}
