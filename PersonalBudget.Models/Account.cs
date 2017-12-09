using System;
using System.Collections.Generic;

namespace PersonalBudget.Models
{
    /// <summary>
    /// Represents an account (credit card, savings, checking, etc.)
    /// </summary>
    public sealed class Account
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