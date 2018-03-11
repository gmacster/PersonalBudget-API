using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Controllers.Common;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Route("api/Budgets")]
    public class BudgetsController : EntityController<Budget>
    {
        public BudgetsController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}