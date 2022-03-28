using FD.ShortUrl.Api.Controllers;
using FD.ShortUrl.Domain;
using FD.ShortUrl.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FD.ShortUrl.xUnit
{
    public class BrainControllerUnitTest
    {
        [Fact]
        public async Task Index_ReturnsAResult_WithAListOfBrainstormSessions()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new BrainController(mockRepo.Object);

            // Act
            var result = await controller.Index();
            
            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<StormSessionViewModel>>(
                viewResult.Value);
            Assert.Equal(2, model.Count());
        }

        private List<BrainstormSession> GetTestSessions()
        {
            var sessions = new List<BrainstormSession>();
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Test One"
            });
            sessions.Add(new BrainstormSession()
            {
                DateCreated = new DateTime(2016, 7, 1),
                Id = 2,
                Name = "Test Two"
            });
            return sessions;
        }


        [Fact]
        public async Task IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.ListAsync())
                .ReturnsAsync(GetTestSessions());
            var controller = new BrainController(mockRepo.Object);
            controller.ModelState.AddModelError("SessionName", "Required");
            var newSession = new BrainController.NewSessionModel();

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.IsType<SerializableError>(badRequestResult.Value);
        }

        [Fact]
        public async Task IndexPost_ReturnsARedirectAndAddsSession_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<BrainstormSession>()))
                .Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new BrainController(mockRepo.Object);
            var newSession = new BrainController.NewSessionModel()
            {
                SessionName = "Test Name"
            };

            // Act
            var result = await controller.Index(newSession);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        }
    }
}