using System;
using System.ComponentModel.DataAnnotations;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a given target for a particular category.
    /// </summary>
    public sealed class BudgetTarget : IEntity
    {
        /// <summary>
        /// Gets or sets the primary key for this <see cref="BudgetTarget"/> instance.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Category"/> for this <see cref="BudgetTarget"/> instance.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the associated <see cref="Category"/> instance.
        /// </summary>
        public Guid? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="BudgetPeriod"/> this <see cref="BudgetTarget"/> is associated to.
        /// </summary>
        public BudgetPeriod BudgetPeriod { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="BudgetPeriod"/> this <see cref="BudgetTarget"/> is associated to.
        /// </summary>
        public Guid BudgetPeriodId { get; set; }

        /// <summary>
        /// Gets or sets the target currency value for this <see cref="BudgetTarget"/> instance.
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal Target { get; set; }
    }
}
