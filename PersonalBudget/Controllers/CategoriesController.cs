using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using PersonalBudget.DataAccessLayer;
using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (await categoryRepository.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await categoryRepository.DeleteAsync(id);
            await categoryRepository.SaveAsync();
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return categoryRepository.GetCategories();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> PostCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await categoryRepository.AddAsync(category);
            await categoryRepository.SaveAsync();

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
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

            categoryRepository.Update(category);
            await categoryRepository.SaveAsync();
            
            return NoContent();
        }
    }
}