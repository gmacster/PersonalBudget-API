using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a container for all associated accounts, categories, transactions, etc.
    /// </summary>
    public sealed class Budget : IEntity
    {
        /// <summary>
        /// Gets or sets the primary key for this <see cref="Budget"/>.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets a friendly name for this <see cref="Budget"/>.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="Account"/> instances that belong to this budget.
        /// </summary>
        public IEnumerable<Account> Accounts { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="BudgetPeriod"/> instances that belong to this budget.
        /// </summary>
        public IEnumerable<BudgetPeriod> BudgetPeriods { get; set; }

        /// <summary>
        /// Gets or sets the collection of <see cref="MasterCategory"/> instances that belong to this budget.
        /// </summary>
        public IEnumerable<MasterCategory> MasterCategories { get; set; }
    }
}
