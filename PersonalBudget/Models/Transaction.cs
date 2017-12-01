using System;

namespace PersonalBudget.Models
{
    public class Transaction
    {
        public Category Category { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public Guid Id { get; set; }

        public decimal Inflow { get; set; }

        public decimal Outflow { get; set; }

        public string Payee { get; set; }
    }
}