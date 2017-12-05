using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/Categories")]
    public class CategoriesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoriesController(IUnitOfWork unitOfWork)
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

            var categoryRepository = unitOfWork.GetRepository<Category>();
            
            if (await categoryRepository.FindAsync(id) == null)
            {
                return NotFound();
            }

            categoryRepository.Delete(id);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IPagedList<Category>> Get()
        {
            return await unitOfWork.GetRepository<Category>().GetPagedListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryRepository = unitOfWork.GetRepository<Category>();
            var category = await categoryRepository.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryRepository = unitOfWork.GetRepository<Category>();
            await categoryRepository.InsertAsync(category);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != category.Id)
            {
                return BadRequest();
            }

            var categoryRepository = unitOfWork.GetRepository<Category>();
            categoryRepository.Update(category);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}