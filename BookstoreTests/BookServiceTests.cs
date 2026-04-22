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
    public class BookServiceTests
    {
        private BookstoreContext context_;
        private BookService service;

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
            service = new BookService(context_);
        }

        [Test]
        public async Task CreateAsync_Should_AddBook()
        {
            var author = new Author { Id = Guid.NewGuid(), FullName = "Author", Biography="lala", ImageUrl="", Nationality =" " };
            var genre = new Genre { Id = Guid.NewGuid(), Name = "Genre", Description="plamen" };

            context_.Authors.Add(author);
            context_.Genres.Add(genre);
            await context_.SaveChangesAsync();

            var model = new BooksCreateViewModel
            {
                Title = "Test Book",
                Price = 10,
                CoverImageUrl = "url",
                Synopsis = "desc",
                AuthorId = author.Id,
                GenreId = genre.Id
            };

            await service.CreateAsync(model);

            context_.Books.Should().HaveCount(1);
        }

        [Test]
        public async Task GetByIdEdit_Should_ReturnBook()
        {
            var author = new Author { Id = Guid.NewGuid(), FullName = "Author", Biography = "lala", ImageUrl = "https", Nationality = "american" };
            var genre = new Genre { Id = Guid.NewGuid(), Name = "Genre", Description = "plamen" };

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                Synopsis = "testche",
                CoverImageUrl = "dje",
                Author = author,
                Genre = genre,
                AuthorId = author.Id,
                GenreId = genre.Id,
                IsInSubscription = true
            };

            context_.AddRange(author, genre, book);
            await context_.SaveChangesAsync();

            var result = await service.GetByIdEdit(book.Id);

            result.Should().NotBeNull();
            result.Title.Should().Be("Test");
        }

        [Test]
        public void EditAsync_Should_Throw_When_NotFound()
        {
            var model = new BooksEditViewModel
            {
                Id = Guid.NewGuid(),
                Title = "Test",
                CoverImageUrl = "htt",
                Price = 6,
                Synopsis = "fy"
            };

            Func<Task> act = async () => await service.EditAsync(model);

            act.Should().ThrowAsync<ArgumentException>();
        }


        [Test]
        public async Task EditAsync_Should_UpdateBook()
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Old",
                Synopsis = "synopsis",
                CoverImageUrl = "https.",
                Price = 5
            };

            context_.Books.Add(book);
            await context_.SaveChangesAsync();

            var model = new BooksEditViewModel
            {
                Id = book.Id,
                Title = "New",
                Price = 20,
                Synopsis="fjihd",
                CoverImageUrl="https://"
            };

            await service.EditAsync(model);

            var updated = context_.Books.First();

            updated.Title.Should().Be("New");
            updated.Price.Should().Be(20);
        }

        [Test]
        public async Task Index_Should_ReturnAllBooks()
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FullName = "Author",
                Biography = "bio",
                Nationality = "bg",
                ImageUrl = "img"
            };

            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Genre",
                Description = "desc"
            };

            var book1 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "A",
                Synopsis = "nufuogr",
                Price = 10,
                CoverImageUrl = "hweiufg",
                IsInSubscription = true,
                Author = author,
                AuthorId = author.Id,
                Genre = genre,
                GenreId = genre.Id
            };

            var book2 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "B",
                Synopsis = "r8ywyo",
                Price = 11,
                CoverImageUrl = "urye",
                IsInSubscription = true,
                Author = author,
                AuthorId = author.Id,
                Genre = genre,
                GenreId = genre.Id
            };

            context_.AddRange(author, genre, book1, book2);
            await context_.SaveChangesAsync();

            var result = await service.Index();

            result.Should().HaveCount(2);
        }

        [Test]
        public async Task DeleteAsync_Should_RemoveBook()
        {
            var book = new Book { Id = Guid.NewGuid(), Title = "C", Synopsis = "nufuogr", Price = 10, CoverImageUrl = "hweiufg", IsInSubscription = true };


            context_.Books.Add(book);
            await context_.SaveChangesAsync();

            await service.DeleteAsync(book.Id);

            context_.Books.Should().BeEmpty();
        }

        [Test]
        public void DeleteAsync_Should_Throw_When_NotFound()
        {
            Func<Task> act = async () => await service.DeleteAsync(Guid.NewGuid());

            act.Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task GetAuthors_Should_ReturnAll()
        {
            context_.Authors.AddRange(
                new Author { Id = Guid.NewGuid(), FullName = "A", Biography="something", Nationality="britsih", ImageUrl="oiy84" },
                new Author { Id = Guid.NewGuid(), FullName = "B", Biography = "great", Nationality = "spanish", ImageUrl = "peo73" }
            );

            await context_.SaveChangesAsync();

            var result = await service.GetAuthors();

            result.Count.Should().Be(2);
        }
        [Test]
        public async Task FilterBooks_ByGenre_Should_Work()
        {
            var author = new Author
            {
                Id = Guid.NewGuid(),
                FullName = "Author",
                Biography = "bio",
                Nationality = "bg",
                ImageUrl = "img"
            };

            var genre = new Genre
            {
                Id = Guid.NewGuid(),
                Name = "Fantasy",
                Description = "wow"
            };

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Back",
                Synopsis = "synopsis3",
                CoverImageUrl = "httpsss.",
                Price = 5,
                Genre = genre,
                GenreId = genre.Id,
                Author = author,
                AuthorId = author.Id
            };

            context_.AddRange(author, genre, book);
            await context_.SaveChangesAsync();

            var result = await service.FilterBooks(null, new List<Guid> { genre.Id }, null, null);

            result.Should().HaveCount(1);
        }

        [Test]
        public async Task FilterBooks_BySearch_Should_Work()
        {
            var author = new Author { Id = Guid.NewGuid(), FullName = "John Doe" , Nationality="bjko", Biography="ewhyhf", ImageUrl="heohfu"};

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "C#",
                Synopsis = "synopsis2",
                CoverImageUrl = "https...",
                Price = 5,
                Author = author,
                AuthorId = author.Id
            };

            context_.AddRange(author, book);
            await context_.SaveChangesAsync();

            var result = await service.FilterBooks("C#", null, null, null);

            result.Should().HaveCount(1);
        }


    }
}
