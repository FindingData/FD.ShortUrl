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
    public class SessionControllerUnitTest
    {
        [Fact]
        public async Task IndexReturnsARedirectToIndexHomeWhenIdIsNull()
        {
            // Arrange
            var controller = new SessionController(sessionRepository: null);

            // Act
            var result = await controller.Index(id: null);

            // Assert
            var redirectToActionResult =
                Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Home", redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }

        [Fact]
        public async Task IndexReturnsContentWithSessionNotFoundWhenSessionNotFound()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync((BrainstormSession)null);
            var controller = new SessionController(mockRepo.Object);

            // Act
            var result = await controller.Index(testSessionId);

            // Assert
            var contentResult = Assert.IsType<ContentResult>(result);
            Assert.Equal("Session not found.", contentResult.Content);
        }

        [Fact]
        public async Task IndexReturnsViewResultWithStormSessionViewModel()
        {
            // Arrange
            int testSessionId = 1;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync(GetTestSessions().FirstOrDefault(
                    s => s.Id == testSessionId));
            var controller = new SessionController(mockRepo.Object);

            // Act
            var result = await controller.Index(testSessionId);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<StormSessionViewModel>(
                viewResult.Value);
            Assert.Equal("Test One", model.Name);
            Assert.Equal(2, model.DateCreated.Day);
            Assert.Equal(testSessionId, model.Id);
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
        public async Task ForSession_ReturnsHttpNotFound_ForInvalidSession()
        {
            // Arrange
            int testSessionId = 123;
            var mockRepo = new Mock<IBrainstormSessionRepository>();
            mockRepo.Setup(repo => repo.GetByIdAsync(testSessionId))
                .ReturnsAsync((BrainstormSession)null);
            var controller = new IdeasController(mockRepo.Object);

            // Act
            var result = await controller.ForSession(testSessionId);

            // Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal(testSessionId, notFoundObjectResult.Value);
        }



    }
}