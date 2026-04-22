using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Books;
using BookstoreProjectData.Entities;
using BookstoreWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;


namespace BookstoreTests
{
    public class BooksControllerTests
    {
        private Mock<IBookService> bookServiceMock;
        private Mock<IReviewService> reviewServiceMock;
        private BooksController controller;

        [SetUp]
        public void Setup()
        {
            bookServiceMock = new Mock<IBookService>();
            reviewServiceMock = new Mock<IReviewService>();

            controller = new BooksController(bookServiceMock.Object, reviewServiceMock.Object);
        }

         [TearDown]
        public void TearDown()
        {
            controller?.Dispose();
        }


        [Test]
        public async Task Index_Should_ReturnView()
        {
            bookServiceMock.Setup(s => s.GetAuthors()).ReturnsAsync(new List<Author>());
            bookServiceMock.Setup(s => s.GetGenres()).ReturnsAsync(new List<Genre>());
            bookServiceMock.Setup(s => s.GetPublishers()).ReturnsAsync(new List<Publisher>());

            var result = await controller.Index(null, null, null, null);

            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public async Task Create_Post_Should_Call_Service_When_Valid()
        {
            var model = new BooksCreateViewModel { Title = "Book" };

            var result = await controller.Create(model);

            bookServiceMock.Verify(s => s.CreateAsync(model), Times.Once);
            result.Should().BeOfType<RedirectToActionResult>();
        }

        [Test]
        public async Task Details_Should_Return_NotFound_When_Null()
        {
            bookServiceMock.Setup(s => s.ShowBookDetails(It.IsAny<Guid>()))
                           .ReturnsAsync((BooksDetailsViewModel)null);

            var result = await controller.Details(Guid.NewGuid());

            result.Should().BeOfType<NotFoundResult>();
        }
    
    }
}
