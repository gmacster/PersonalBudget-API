using System;
using System.Collections.Generic;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a categorical grouping for transactions.
    /// </summary>
    public sealed class Category : IEntity
    {
        /// <summary>
        /// Gets or sets the category's ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the master category.
        /// </summary>
        public MasterCategory MasterCategory { get; set; }

        /// <summary>
        /// Gets or sets the ID of the related master category.
        /// </summary>
        public Guid MasterCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of <see cref="Transaction" />s that belong to this category.
        /// </summary>
        public List<Transaction> Transactions { get; set; }
    }
}