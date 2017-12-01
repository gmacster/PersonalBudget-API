namespace PersonalBudget.Models
{
    using System;

    public class Transaction
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public string Payee { get; set; }

        public Category Category { get; set; }

        public string Description { get; set; }

        public decimal Outflow { get; set; }

        public decimal Inflow { get; set; }
    }
}
