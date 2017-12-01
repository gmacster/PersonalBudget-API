using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBudget.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using PersonalBudget.Data;
    using PersonalBudget.Models;

    [Produces("application/json")]
    [Route("api/Transactions")]
    public class TransactionsController : Controller
    {
        private readonly PersonalBudgetContext context;

        public TransactionsController(PersonalBudgetContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get()
        {
            return context.Transaction;
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = await context.Transaction.SingleOrDefaultAsync(m => m.Id == id);
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
            
            await context.Transaction.AddAsync(transaction);
            await context.SaveChangesAsync();

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

            context.Entry(transaction).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool found = await context.Transaction.AnyAsync(m => m.Id == id);
                if (!found)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = await context.Transaction.SingleOrDefaultAsync(m => m.Id == id);
            if (transaction == null)
            {
                return NotFound();
            }

            context.Transaction.Remove(transaction);
            await context.SaveChangesAsync();

            return Ok(transaction);
        }
    }
}
