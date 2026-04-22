using BookstoreProjectCore.Models.Events;
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
    internal class EventServiceTests
    {
        private BookstoreContext context_;
        private EventService service;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context_ = new BookstoreContext(options);
            service = new EventService(context_);
        }

        [TearDown]
        public void TearDown()
        {
            context_.Dispose();
        }

        [Test]
        public async Task Index_Should_ReturnEvents()
        {
            var author = new Author { Id = Guid.NewGuid(), FullName = "A", Nationality = "B", Biography = "C", ImageUrl = "D" };

            var ev = new Event
            {
                Id = Guid.NewGuid(),
                Name = "Event",
                Author = author,
                DateAndTime = DateTime.Now,
                Link="tr"
            };

            context_.AddRange(author, ev);
            await context_.SaveChangesAsync();

            var result = await service.Index();

            result.Should().HaveCount(1);
        }

        [Test]
        public async Task GetById_Should_ReturnEvent()
        {
            var author = new Author { Id = Guid.NewGuid(), FullName = "A", Nationality = "B", Biography = "C", ImageUrl = "D" };

            var ev = new Event
            {
                Id = Guid.NewGuid(),
                Name = "Event",
                Author = author,
                DateAndTime = DateTime.Now,
                Link="duiergy"
            };

            context_.AddRange(author, ev);
            await context_.SaveChangesAsync();

            var result = await service.GetById(ev.Id);

            result.Should().NotBeNull();
        }

        [Test]
        public void EditAsync_Should_Throw_When_NotFound()
        {
            var dto = new EventsEditViewModel { Id = Guid.NewGuid() };

            Func<Task> act = async () => await service.EditAsync(dto);

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task DeleteAsync_Should_Remove()
        {
            var ev = new Event { Id = Guid.NewGuid(), Name = "E", DateAndTime= new DateTime(), Link="dbuifb" };

            context_.Events.Add(ev);
            await context_.SaveChangesAsync();

            await service.DeleteAsync(ev.Id);

            context_.Events.Should().BeEmpty();
        }
    }
}
