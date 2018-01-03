using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Models
{
    public sealed class BudgetPeriod : IEntity
    {
        public Guid Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodStartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime PeriodEndDate { get; set; }

        public IEnumerable<BudgetTarget> BudgetTargets { get; set; }
    }
}
