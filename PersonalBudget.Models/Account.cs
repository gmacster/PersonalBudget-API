using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents an account (credit card, savings, checking, etc.)
    /// </summary>
    public sealed class Account : IEntity
    {
        /// <summary>
        /// Gets or sets the account's primary key.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Budget"/> to which this <see cref="Account"/> belongs.
        /// </summary>
        public Budget Budget { get; set; }

        /// <summary>
        /// Gets or sets the primary key of the <see cref="Budget"/> to which this <see cref="Account"/> belongs.
        /// </summary>
        public Guid BudgetId { get; set; }

        /// <summary>
        /// Gets or sets the account's name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of transactions associated with the account.
        /// </summary>
        public List<Transaction> Transactions { get; set; }
    }
}