using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Moq;

using PersonalBudget.Controllers.Common;

using Xunit;

namespace PersonalBudget.Tests
{
    public sealed class EntityControllerTests
    {
        private readonly Mock<IUnitOfWork> unitOfWorkMock;

        private readonly Mock<IRepository<MockEntity>> repositoryMock;

        public EntityControllerTests()
        {
            repositoryMock = new Mock<IRepository<MockEntity>>();

            unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(m => m.GetRepository<MockEntity>()).Returns(repositoryMock.Object);
        }

        [Fact]
        public async Task GetAndDelete_WithNoMatch_ReturnsNotFoundResult()
        {
            // Arrange
            repositoryMock.Setup(r => r.FindAsync(It.IsAny<object[]>())).ReturnsAsync(value: null);

            // Act/Assert
            var controller = new EntityController<MockEntity>(unitOfWorkMock.Object);
            Assert.IsAssignableFrom<NotFoundResult>(await controller.Get(Guid.Empty));
            Assert.IsAssignableFrom<NotFoundResult>(await controller.Delete(Guid.Empty));
        }

        [Fact]
        public async Task GetPostPutDelete_WithInvalidModelState_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var controller = new EntityController<MockEntity>(unitOfWorkMock.Object);
            controller.ModelState.AddModelError("some-error-key", "Some error message");

            // Act/Assert
            Assert.IsAssignableFrom<BadRequestObjectResult>(await controller.Get(Guid.Empty));
            Assert.IsAssignableFrom<BadRequestObjectResult>(await controller.Post(new MockEntity(Guid.NewGuid())));
            Assert.IsAssignableFrom<BadRequestObjectResult>(await controller.Put(Guid.Empty, new MockEntity(Guid.NewGuid())));
            Assert.IsAssignableFrom<BadRequestObjectResult>(await controller.Delete(Guid.Empty));
        }

        [Fact]
        public async Task Put_WithMismatchedEntityId_ReturnsBadRequestResult()
        {
            // Arrange
            var controller = new EntityController<MockEntity>(unitOfWorkMock.Object);

            // Act/Assert
            Assert.IsAssignableFrom<BadRequestResult>(await controller.Put(Guid.Empty, new MockEntity(Guid.NewGuid())));
        }
    }
}
