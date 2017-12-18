using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Moq;

using PersonalBudget.Controllers;
using PersonalBudget.Models;

using Xunit;

namespace PersonalBudget.Tests
{
    public class AccountsControllerTests
    {
        [Fact]
        public async Task Get_WithNoMatch_ReturnsNotFoundResult()
        {
            // Arrange
            var repositoryMock = new Mock<IRepository<Account>>();
            repositoryMock.Setup(m => m.FindAsync(It.IsAny<object[]>())).ReturnsAsync((Account)null);

            var mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.GetRepository<Account>()).Returns(repositoryMock.Object);
            
            // Act
            var controller = new AccountsController(mock.Object);
            var result = await controller.Get(Guid.Empty);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }
    }
}
