using PersonalBudget.Models;
using PersonalBudget.Tests.Helpers;

using Xunit;

namespace PersonalBudget.Tests
{
    public sealed class AccountValidationTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("\t")]
        [InlineData(" ")]
        public void ValidateAccount_WithInvalidName_FailsValidation(string name)
        {
            var account = new Account { Name = name };

            var validationResults = ValidationHelpers.ValidateModel(account);

            Assert.Single(validationResults);
        }
    }
}
