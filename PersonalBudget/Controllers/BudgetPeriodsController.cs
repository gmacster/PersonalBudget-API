using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Controllers.Common;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Route("api/BudgetPeriods")]
    public class BudgetPeriodsController : EntityController<BudgetPeriod>
    {
        public BudgetPeriodsController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}