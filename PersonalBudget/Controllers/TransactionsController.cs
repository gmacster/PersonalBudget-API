using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Controllers.Common;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Route("api/Transactions")]
    public class TransactionsController : EntityController<Transaction>
    {
        public TransactionsController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}