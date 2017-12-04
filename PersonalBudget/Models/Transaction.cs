using System;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents a single transaction.
    /// </summary>
    public class Transaction
    {
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
        public decimal Inflow { get; set; }

        /// <summary>
        /// Gets or sets the transaction's outflow amount.
        /// </summary>
        public decimal Outflow { get; set; }

        /// <summary>
        /// Gets or sets the payee.
        /// </summary>
        public string Payee { get; set; }
    }
}