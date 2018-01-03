using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    public sealed class BudgetPeriod : IEntity, IValidatableObject
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodEndDate { get; set; }

        public IEnumerable<BudgetTarget> BudgetTargets { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.PeriodEndDate <= this.PeriodStartDate)
            {
                yield return new ValidationResult(
                    $"{nameof(PeriodEndDate)} must be greater than {nameof(PeriodStartDate)}.",
                    new[] { nameof(PeriodStartDate), nameof(PeriodEndDate) });
            }
            else
            {
                yield return ValidationResult.Success;
            }
        }
    }
}
