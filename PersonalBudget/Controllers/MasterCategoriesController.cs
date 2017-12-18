using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Controllers.Common;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Route("api/MasterCategories")]
    public class MasterCategoriesController : EntityController<MasterCategory>
    {
        public MasterCategoriesController(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}