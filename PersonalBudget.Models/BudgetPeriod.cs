using System;
using System.Collections.Generic;

namespace PersonalBudget.Models
{
    public sealed class BudgetPeriod
    {
        public Guid Id { get; set; }

        public DateTime PeriodStartDate { get; set; }

        public DateTime PeriodEndDate { get; set; }

        public IEnumerable<BudgetTarget> BudgetTargets { get; set; }
    }
}
