using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Controllers.Common;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Route("api/Accounts")]
    public class AccountsController : EntityController<Account>
    {
        public AccountsController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}