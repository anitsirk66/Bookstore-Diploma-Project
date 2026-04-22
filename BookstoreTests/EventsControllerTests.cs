using BookstoreProjectCore.Contracts;
using BookstoreProjectCore.Models.Events;
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
    public class EventsControllerTests
    {
        private Mock<IEventService> serviceMock;
        private EventsController controller;

        [SetUp]
        public void Setup()
        {
            serviceMock = new Mock<IEventService>();
            controller = new EventsController(serviceMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            controller?.Dispose();
        }

        [Test]
        public async Task Index_Should_ReturnView()
        {
            serviceMock.Setup(s => s.Index()).ReturnsAsync(new List<EventsIndexViewModel>());

            var result = await controller.Index();

            result.Should().BeOfType<ViewResult>();
        }

        [Test]
        public async Task Create_Post_Should_Call_Service_When_Valid()
        {
            var model = new EventsCreateViewModel { Name = "Event" };

            var result = await controller.Create(model);

            serviceMock.Verify(s => s.CreateAsync(model), Times.Once);
            result.Should().BeOfType<RedirectToActionResult>();
        }

        [Test]
        public async Task Edit_Get_Should_Return_NotFound_When_Null()
        {
            serviceMock.Setup(s => s.GetEditById(It.IsAny<Guid>()))
                       .ReturnsAsync((EventsEditViewModel)null);

            var result = await controller.Edit(Guid.NewGuid());

            result.Should().BeOfType<NotFoundResult>();
        }

        [Test]
        public async Task Delete_Should_Call_Service()
        {
            var id = Guid.NewGuid();

            var result = await controller.Delete(id);

            serviceMock.Verify(s => s.DeleteAsync(id), Times.Once);
            result.Should().BeOfType<RedirectToActionResult>();
        }
    }
}
