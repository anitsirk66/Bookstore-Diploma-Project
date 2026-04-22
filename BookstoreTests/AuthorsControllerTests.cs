using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Authors;
using BookstoreProjectCore.Services;
using BookstoreProjectData;
using BookstoreWebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace BookstoreTests
{
    public class AuthorsControllerTests
    {
        private Mock<IAuthorService> serviceMock;
        private AuthorsController controller;

        [SetUp]
        public void Setup()
        {
            serviceMock = new Mock<IAuthorService>();
            controller = new AuthorsController(serviceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            controller?.Dispose();
        }

        [Test]
        public async Task Index_Should_ReturnView_WithAuthors()
        {
            var authors = new List<AuthorsIndexViewModel>
        {
            new AuthorsIndexViewModel { FullName = "Test" }
        };

            serviceMock.Setup(s => s.Index()).ReturnsAsync(authors);

            var result = await controller.Index() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(authors);
        }

        [Test]
        public async Task Create_Post_Should_Redirect_When_Valid()
        {
            var model = new AuthorsCreateViewModel { FullName = "A" };

            var result = await controller.Create(model);

            result.Should().BeOfType<RedirectToActionResult>();
            serviceMock.Verify(s => s.CreateAsync(model), Times.Once);
        }

        [Test]
        public async Task Create_Post_Should_ReturnView_When_Invalid()
        {
            controller.ModelState.AddModelError("FullName", "Required");

            var model = new AuthorsCreateViewModel();

            var result = await controller.Create(model);

            result.Should().BeOfType<ViewResult>();
            serviceMock.Verify(s => s.CreateAsync(It.IsAny<AuthorsCreateViewModel>()), Times.Never);
        }

        [Test]
        public async Task Delete_Should_Call_Service()
        {
            var id = Guid.NewGuid();

            var result = await controller.Delete(id);

            serviceMock.Verify(s => s.DeleteAsync(id), Times.Once);
            result.Should().BeOfType<RedirectToActionResult>();
        }

        [Test]
        public async Task Edit_Get_Should_Return_NotFound_When_Null()
        {
            serviceMock.Setup(s => s.GetEditById(It.IsAny<Guid>()))
                       .ReturnsAsync((AuthorsEditViewModel)null);

            var result = await controller.Edit(Guid.NewGuid());

            result.Should().BeOfType<NotFoundResult>();
        }
    }
}
