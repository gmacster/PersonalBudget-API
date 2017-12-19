using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Moq;

using PersonalBudget.Controllers.Common;

using Xunit;

namespace PersonalBudget.Tests
{
    public class EntityControllerTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        private readonly Mock<IRepository<MockEntity>> _repositoryMock;

        public EntityControllerTests()
        {
            _repositoryMock = new Mock<IRepository<MockEntity>>();

            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _unitOfWorkMock.Setup(m => m.GetRepository<MockEntity>()).Returns(_repositoryMock.Object);
        }

        [Fact]
        public async Task GetAndDelete_WithNoMatch_ReturnsNotFoundResult()
        {
            // Arrange
            _repositoryMock.Setup(r => r.FindAsync(It.IsAny<object[]>())).ReturnsAsync(default(MockEntity));

            // Act/Assert
            var controller = new EntityController<MockEntity>(_unitOfWorkMock.Object);
            Assert.IsAssignableFrom<NotFoundResult>(await controller.Get(Guid.Empty));
            Assert.IsAssignableFrom<NotFoundResult>(await controller.Delete(Guid.Empty));
        }

        [Fact]
        public async Task GetPostPutDelete_WithInvalidModelState_ReturnsBadRequestObjectResult()
        {
            // Arrange
            var controller = new EntityController<MockEntity>(_unitOfWorkMock.Object);
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
            var controller = new EntityController<MockEntity>(_unitOfWorkMock.Object);

            // Act/Assert
            Assert.IsAssignableFrom<BadRequestResult>(await controller.Put(Guid.Empty, new MockEntity(Guid.NewGuid())));
        }
    }
}
