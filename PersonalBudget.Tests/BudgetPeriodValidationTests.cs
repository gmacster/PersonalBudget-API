using System;

using PersonalBudget.Models;
using PersonalBudget.Tests.Helpers;

using Xunit;

namespace PersonalBudget.Tests
{
    public sealed class BudgetPeriodValidationTests
    {
        [Fact]
        public void ValidateBudgetPeriod_WithStartDateGreaterThanEndDate_FailsValidation()
        {
            var account = new BudgetPeriod { PeriodStartDate = DateTime.MaxValue, PeriodEndDate = DateTime.MinValue };

            var validationResults = ValidationHelpers.ValidateModel(account);

            Assert.Single(validationResults);
        }
    }
}
