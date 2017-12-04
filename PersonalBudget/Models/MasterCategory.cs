using System;
using System.Collections.Generic;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a categorical grouping for categories.
    /// </summary>
    public sealed class MasterCategory
    {
        /// <summary>
        /// Gets or sets the master category's ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the master category name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the child categories.
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }
    }
}
