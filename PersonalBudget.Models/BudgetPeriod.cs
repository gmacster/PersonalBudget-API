using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a date range transactions are grouped within.
    /// </summary>
    public sealed class BudgetPeriod : IEntity, IValidatableObject
    {
        /// <summary>
        /// Gets or sets the primary key for this <see cref="BudgetPeriod"/> instance.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Budget"/> to which this <see cref="BudgetPeriod"/> belongs.
        /// </summary>
        public Budget Budget { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Budget"/> to which this <see cref="BudgetPeriod"/> belongs.
        /// </summary>
        public Guid BudgetId { get; set; }

        /// <summary>
        /// Gets or sets the start date for this <see cref="BudgetPeriod"/> instance.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodStartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date for this <see cref="BudgetPeriod"/> instance.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodEndDate { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="BudgetTarget"/> instances associated with this <see cref="BudgetPeriod"/>.
        /// </summary>
        public IEnumerable<BudgetTarget> BudgetTargets { get; set; }

        /// <summary>
        /// Validates this <see cref="BudgetPeriod"/> instance against business rules.
        /// </summary>
        /// <param name="validationContext">The current <see cref="ValidationContext"/>.</param>
        /// <returns>A collection of validation results.</returns>
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
