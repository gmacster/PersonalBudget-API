using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/BudgetPeriods")]
    public class BudgetPeriodsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public BudgetPeriodsController(IUnitOfWork unitOfWork)
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

            var budgetPeriodRepository = unitOfWork.GetRepository<BudgetPeriod>();
            
            if (await budgetPeriodRepository.FindAsync(id) == null)
            {
                return NotFound();
            }

            budgetPeriodRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IPagedList<BudgetPeriod>> Get()
        {
            return await unitOfWork.GetRepository<BudgetPeriod>().GetPagedListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetPeriodRepository = unitOfWork.GetRepository<BudgetPeriod>();
            var budgetPeriod = await budgetPeriodRepository.FindAsync(id);
            if (budgetPeriod == null)
            {
                return NotFound();
            }

            return Ok(budgetPeriod);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BudgetPeriod budgetPeriod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var budgetPeriodRepository = unitOfWork.GetRepository<BudgetPeriod>();
            await budgetPeriodRepository.InsertAsync(budgetPeriod);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = budgetPeriod.Id }, budgetPeriod);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] BudgetPeriod budgetPeriod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != budgetPeriod.Id)
            {
                return BadRequest();
            }

            var budgetPeriodRepository = unitOfWork.GetRepository<BudgetPeriod>();
            budgetPeriodRepository.Update(budgetPeriod);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}