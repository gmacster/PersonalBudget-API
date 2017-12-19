using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Controllers.Common;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Route("api/Categories")]
    public class CategoriesController : EntityController<Category>
    {
        public CategoriesController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}