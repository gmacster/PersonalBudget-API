using System;
using System.Collections.Generic;

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
        /// Gets or sets the account's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the list of transactions associated with the account.
        /// </summary>
        public List<Transaction> Transactions { get; set; }
    }
}