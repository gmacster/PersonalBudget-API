using System;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    public sealed class BudgetTarget : IEntity
    {
        public Guid Id { get; set; }

        public Category Category { get; set; }

        public Guid CategoryId { get; set; }

        public BudgetPeriod BudgetPeriod { get; set; }

        public Guid BudgetPeriodId { get; set; }

        public decimal Target { get; set; }
    }
}
