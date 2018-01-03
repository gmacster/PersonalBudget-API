using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a categorical grouping for categories.
    /// </summary>
    public sealed class MasterCategory : IEntity
    {
        /// <summary>
        /// Gets or sets the child categories.
        /// </summary>
        public IEnumerable<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the master category's ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the master category name.
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}