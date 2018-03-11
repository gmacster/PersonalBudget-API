using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models.Interfaces;

namespace PersonalBudget.Controllers.Common
{
    [Produces("application/json")]
    public class EntityController<T> : Controller where T : class, IEntity
    {
        private readonly IUnitOfWork unitOfWork;

        public EntityController(IUnitOfWork unitOfWork)
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

            var repository = unitOfWork.GetRepository<T>();

            var match = await repository.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }

            repository.Delete(match);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<IPagedList<T>> Get()
        {
            return await unitOfWork.GetRepository<T>().GetPagedListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var repository = unitOfWork.GetRepository<T>();
            var entity = await repository.FindAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var repository = unitOfWork.GetRepository<T>();
            await repository.InsertAsync(entity);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = entity.Id }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] Guid id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != entity.Id)
            {
                return BadRequest();
            }

            var budgetTargetRepository = unitOfWork.GetRepository<T>();
            budgetTargetRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}
