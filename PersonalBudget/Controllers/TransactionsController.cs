using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public TransactionsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionRepository = unitOfWork.GetRepository<Transaction>();
            var transaction = await transactionRepository.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            transactionRepository.Delete(transaction);
            await unitOfWork.SaveChangesAsync();

            return Ok(transaction);
        }

        [HttpGet]
        public async Task<IPagedList<Transaction>> Get()
        {
            return await unitOfWork.GetRepository<Transaction>().GetPagedListAsync();
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionRepository = unitOfWork.GetRepository<Transaction>();
            var transaction = await transactionRepository.FindAsync(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transactionRepository = unitOfWork.GetRepository<Transaction>();
            await transactionRepository.InsertAsync(transaction);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Post), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Transaction transaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != transaction.Id)
            {
                return BadRequest();
            }

            var transactionRepository = unitOfWork.GetRepository<Transaction>();
            transactionRepository.Update(transaction);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}