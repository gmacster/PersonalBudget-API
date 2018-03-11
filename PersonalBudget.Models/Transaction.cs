using System;
using System.ComponentModel.DataAnnotations;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a single transaction.
    /// </summary>
    public sealed class Transaction : IEntity
    {
        /// <summary>
        /// Gets or sets the <see cref="Account" /> for the transaction.
        /// </summary>
        public Account Account { get; set; }

        /// <summary>
        /// Gets or sets the ID of the transaction's related <see cref="Account" />.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Category" /> for the transaction.
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Gets or sets the ID of the transaction's related category.
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the date on which the transaction occurred.
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets a description for the transaction.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the transaction's ID.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the transaction's inflow amount.
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal Inflow { get; set; }

        /// <summary>
        /// Gets or sets the transaction's outflow amount.
        /// </summary>
        [Required]
        [DataType(DataType.Currency)]
        public decimal Outflow { get; set; }

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        [Required]
        public string Payee { get; set; }
    }
}