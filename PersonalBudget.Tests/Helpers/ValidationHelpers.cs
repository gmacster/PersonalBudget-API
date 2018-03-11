using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalBudget.Tests.Helpers
{
    internal static class ValidationHelpers
    {
        public static IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
