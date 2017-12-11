using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/BudgetTargets")]
    public class BudgetTargetsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BudgetTargetsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetTargetRepository = unitOfWork.GetRepository<BudgetTarget>();
            
            if (await budgetTargetRepository.FindAsync(id) == null)
            {
                return NotFound();
            }

            budgetTargetRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IPagedList<BudgetTarget>> Get()
        {
            return await unitOfWork.GetRepository<BudgetTarget>().GetPagedListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetTargetRepository = unitOfWork.GetRepository<BudgetTarget>();
            var budgetTarget = await budgetTargetRepository.FindAsync(id);
            if (budgetTarget == null)
            {
                return NotFound();
            }

            return Ok(budgetTarget);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BudgetTarget budgetTarget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetTargetRepository = unitOfWork.GetRepository<BudgetTarget>();
            await budgetTargetRepository.InsertAsync(budgetTarget);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = budgetTarget.Id }, budgetTarget);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] BudgetTarget budgetTarget)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != budgetTarget.Id)
            {
                return BadRequest();
            }

            var budgetTargetRepository = unitOfWork.GetRepository<BudgetTarget>();
            budgetTargetRepository.Update(budgetTarget);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}