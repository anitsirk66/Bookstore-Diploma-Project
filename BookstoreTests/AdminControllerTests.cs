using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Interfaces;
using BookstoreProjectCore.Models.Books;
using BookstoreWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using BookstoreProjectData.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;


namespace BookstoreTests
{
    public class AdminControllerTests
    {
        private Mock<IBookService> bookServiceMock;
        private Mock<IMonthlySelectionService> monthlyMock;
        private AdminController controller;

        [SetUp]
        public void Setup()
        {
            bookServiceMock = new Mock<IBookService>();
            monthlyMock = new Mock<IMonthlySelectionService>();

            controller = new AdminController(bookServiceMock.Object, monthlyMock.Object);
        }
        [TearDown]
        public void TearDown()
        {
            controller?.Dispose();
        }

        [Test]
        public async Task Create_Get_Should_Return_View()
        {
            bookServiceMock.Setup(s => s.Index()).ReturnsAsync(new List<BooksIndexViewModel>());

            var result = await controller.Create();

            result.Should().BeOfType<ViewResult>();
        }

    }
}
