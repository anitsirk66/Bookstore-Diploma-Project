using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using BookstoreProjectData;
using BookstoreProjectData.Entities;
using BookstoreProjectCore.Services;
using BookstoreProjectCore.Models.Books;
using FluentAssertions;
using BookstoreProjectCore.Models.Genres;
using BookstoreWebApp.Models.Reviews;
using BookstoreProjectCore.Models.Reviews;

namespace BookstoreTests
{
    public class GenreServiceTests
    {
        private BookstoreContext context;
        private GenreService service;


        [TearDown]
        public void TearDown()
        {
            context.Dispose();
        }

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            context = new BookstoreContext(options);
            service = new GenreService(context);
        }

        //[Test]
        //public async Task Should_ReturnFalse_When_NotExactlyThreeBooksSelected()
        //{
        //    // Arrange
        //    context.Books.AddRange(
        //        new Book { Id = Guid.NewGuid(), Title = "Book 1" },
        //        new Book { Id = Guid.NewGuid(), Title = "Book 2" }
        //    );

        //    await context.SaveChangesAsync();

        //    var model = new List<BookSelectionViewModel>
        //    {
        //        new BookSelectionViewModel { Id = Guid.NewGuid(), IsSelected = true },
        //        new BookSelectionViewModel { Id = Guid.NewGuid(), IsSelected = true }
        //    };

        //    // Act
        //    var result = await service.UpdateSubscriptionBooks(model);

        //    // Assert
        //    result.Should().BeFalse();
        //}

        //жанр
        [Test]
        public async Task Index_Should_ReturnAllGenres()
        {
            context.Genres.AddRange(
                new Genre { Id = Guid.NewGuid(), Name = "Fantasy", Description = "Test" },
                new Genre { Id = Guid.NewGuid(), Name = "Sci-Fi", Description = "Test" }
            );

            await context.SaveChangesAsync();

            var service = new GenreService(context);

            var result = await service.Index();

            result.Should().HaveCount(2);
        }

        [Test]
        public async Task CreateAsync_Should_AddGenre()
        {
            var service = new GenreService(context);

            var model = new GenresCreateViewModel
            {
                Name = "Horror",
                Desciption = "Scary"
            };

            await service.CreateAsync(model);

            context.Genres.Should().HaveCount(1);
            context.Genres.First().Name.Should().Be("Horror");
        }

        [Test]
        public async Task EditAsync_Should_UpdateGenre()
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Old",
                Description = "Old desc"
            };

            context.Genres.Add(genre);
            await context.SaveChangesAsync();

            var service = new GenreService(context);

            var model = new GenresEditViewModel
            {
                Id = genre.Id,
                Name = "New",
                Desciption = "New desc"
            };

            await service.EditAsync(model);

            var updated = context.Genres.First();

            updated.Name.Should().Be("New");
        }

        [Test]
        public void EditAsync_Should_Throw_When_GenreNotFound()
        {
            var service = new GenreService(context);

            var model = new GenresEditViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Test"
            };

            Func<Task> act = async () => await service.EditAsync(model);

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task DeleteAsync_Should_RemoveGenre()
        {
            var genre = new Genre { Id = Guid.NewGuid(), Name = "Test", Description = "az" };

            context.Genres.Add(genre);
            await context.SaveChangesAsync();

            var service = new GenreService(context);

            await service.DeleteAsync(genre.Id);

            context.Genres.Should().BeEmpty();
        }

        [Test]
        public void DeleteAsync_Should_Throw_When_GenreHasBooks()
        {
            var genreId = Guid.NewGuid();

            context.Genres.Add(new Genre { Id = genreId, Name = "Test2", Description="abcdefg" });
            context.Books.Add(new Book { Id = Guid.NewGuid(), GenreId = genreId, Title="Book", Synopsis="cool", CoverImageUrl="eyryy3", Price=13 });

            context.SaveChanges();

            var service = new GenreService(context);

            Func<Task> act = async () => await service.DeleteAsync(genreId);

            act.Should().ThrowAsync<Exception>();
        }

        [Test]
        public void DeleteAsync_Should_Throw_When_NotFound()
        {
            var service = new GenreService(context);

            Func<Task> act = async () => await service.DeleteAsync(Guid.NewGuid());

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task GetEditById_Should_ReturnCorrectModel()
        {
            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Description = "Desc"
            };

            context.Genres.Add(genre);
            await context.SaveChangesAsync();

            var service = new GenreService(context);

            var result = await service.GetEditById(genre.Id);

            result.Should().NotBeNull();
            result.Name.Should().Be("Test");
        }


    }
}