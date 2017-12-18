using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Controllers.Common;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Route("api/BudgetTargets")]
    public class BudgetTargetsController : EntityController<BudgetTarget>
    {
        public BudgetTargetsController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}