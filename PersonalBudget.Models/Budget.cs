using System;
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
    }
}
