namespace PersonalBudget.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using PersonalBudget.Data;
    using PersonalBudget.Models;

    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly PersonalBudgetContext context;

        public CategoriesController(PersonalBudgetContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Category> GetCategory()
        {
            return context.Category;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await context.Category.SingleOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory([FromRoute] Guid id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            context.Entry(category).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var found = await context.Category.AnyAsync(e => e.Id == id);
                if (!found)
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await context.Category.AddAsync(category);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategory), new { id = category.Id }, category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await context.Category.SingleOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            context.Category.Remove(category);
            await context.SaveChangesAsync();

            return Ok(category);
        }
    }
}