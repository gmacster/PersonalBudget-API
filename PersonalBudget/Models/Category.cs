using System;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a categorical grouping for transactions.
    /// </summary>
    public sealed class Category
    {
        /// <summary>
        /// Gets or sets the category's ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the category name.
        /// </summary>
        public string Name { get; set; }
    }
}