using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.Controllers
{
    [Produces("application/json")]
    [Route("api/MasterCategories")]
    public class MasterCategoriesController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public MasterCategoriesController(IUnitOfWork unitOfWork)
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

            var masterCategoryRepository = unitOfWork.GetRepository<MasterCategory>();
            var masterCategory = await masterCategoryRepository.FindAsync(id);
            if (masterCategory == null)
            {
                return NotFound();
            }

            masterCategoryRepository.Delete(masterCategory);
            await unitOfWork.SaveChangesAsync();

            return Ok(masterCategory);
        }

        [HttpGet]
        public async Task<IPagedList<MasterCategory>> Get()
        {
            return await unitOfWork.GetRepository<MasterCategory>().GetPagedListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var masterCategoryRepository = unitOfWork.GetRepository<MasterCategory>();
            var masterCategory = await masterCategoryRepository.FindAsync(id);

            if (masterCategory == null)
            {
                return NotFound();
            }

            return Ok(masterCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MasterCategory category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var masterCategoryRepository = unitOfWork.GetRepository<MasterCategory>();
            await masterCategoryRepository.InsertAsync(category);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = category.Id }, category);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] MasterCategory masterCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != masterCategory.Id)
            {
                return BadRequest();
            }

            var masterCategoryRepository = unitOfWork.GetRepository<MasterCategory>();
            masterCategoryRepository.Update(masterCategory);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}