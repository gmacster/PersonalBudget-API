using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace PersonalBudget.DataAccessLayer.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        private readonly PersonalBudgetContext context;

        private readonly DbSet<TEntity> dbSet;

        public Repository(PersonalBudgetContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            dbSet.Update(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            dbSet.Remove(entity);
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
