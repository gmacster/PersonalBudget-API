using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.DataAccessLayer;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/MasterCategories")]
    public class MasterCategoriesController : Controller
    {
        private readonly PersonalBudgetContext context;

        public MasterCategoriesController(PersonalBudgetContext context)
        {
            this.context = context;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var masterCategory = await context.MasterCategory.SingleOrDefaultAsync(m => m.Id == id);
            if (masterCategory == null)
            {
                return NotFound();
            }

            context.MasterCategory.Remove(masterCategory);
            await context.SaveChangesAsync();

            return Ok(masterCategory);
        }

        [HttpGet]
        public IEnumerable<MasterCategory> Get()
        {
            return context.MasterCategory;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var masterCategory = await context.MasterCategory.SingleOrDefaultAsync(m => m.Id == id);

            if (masterCategory == null)
            {
                return NotFound();
            }

            return Ok(masterCategory);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] MasterCategory category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await context.MasterCategory.AddAsync(category);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] Guid id, [FromBody] MasterCategory masterCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != masterCategory.Id)
            {
                return BadRequest();
            }

            context.Entry(masterCategory).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var found = await context.MasterCategory.AnyAsync(e => e.Id == id);
                if (!found)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }
    }
}