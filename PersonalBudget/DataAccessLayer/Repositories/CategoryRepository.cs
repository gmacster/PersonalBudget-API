using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PersonalBudget.Models;

namespace PersonalBudget.DataAccessLayer.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly PersonalBudgetContext context;

        public CategoryRepository(PersonalBudgetContext context)
        {
            this.context = context;
        }

        public IEnumerable<Category> GetCategories()
        {
            return context.Category;
        }

        public async Task<Category> GetByIdAsync(Guid id)
        {
            return await context.Category.FindAsync(id);
        }

        public async Task AddAsync(Category category)
        {
            await context.Category.AddAsync(category);
        }

        public void Update(Category category)
        {
            context.Category.Update(category);
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await context.Category.FindAsync(id);
            context.Category.Remove(category);
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}