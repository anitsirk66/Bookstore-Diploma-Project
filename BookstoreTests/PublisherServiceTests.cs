using BookstoreProjectCore.Models.Publishers;
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
    public class PublisherServiceTests
    {
        private BookstoreContext context_;
        private PublisherService service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context_ = new BookstoreContext(options);
            service = new PublisherService(context_);
        }

        [TearDown]
        public void TearDown()
        {
            context_.Dispose();
        }

        [Test]
        public async Task IndexAsync_Should_ReturnAll()
        {
            context_.Publishers.Add(new Publisher { Id = Guid.NewGuid(), Name = "P", Description="d" });

            await context_.SaveChangesAsync();

            var result = await service.IndexAsync();

            result.Should().HaveCount(1);
        }

        [Test]
        public async Task CreateAsync_Should_AddPublisher_WithBooks()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Book1",
                Price = 10,
                CoverImageUrl = "img",
                Synopsis = "s"
            };

            context_.Books.Add(book);
            await context_.SaveChangesAsync();

            var model = new PublishersCreateViewModel
            {
                Name = "P",
                Description = "D",
                SelectedBookIds = new List<Guid> { book.Id }
            };
            
            await service.CreateAsync(model);

            context_.Publishers.Should().HaveCount(1);
            context_.Set<Publisher_Book>().Should().HaveCount(1);
        }

        [Test]
        public void DeleteAsync_Should_Throw_When_NotFound()
        {
            Func<Task> act = async () => await service.DeleteAsync(Guid.NewGuid());

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task DeleteAsync_Should_RemovePublisher()
        {
            var publisher = new Publisher
            {
                Id = Guid.NewGuid(),
                Publishers_Books = new List<Publisher_Book>(),
                Description="rui",
                Name="orange"
            };

            context_.Publishers.Add(publisher);
            await context_.SaveChangesAsync();

            await service.DeleteAsync(publisher.Id);

            context_.Publishers.Should().BeEmpty();
        }
    }
}
