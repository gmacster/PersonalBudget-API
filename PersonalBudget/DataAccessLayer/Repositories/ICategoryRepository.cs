using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using PersonalBudget.Models;

namespace PersonalBudget.DataAccessLayer
{
    public interface ICategoryRepository : IDisposable
    {
        IEnumerable<Category> GetCategories();

        Task<Category> GetByIdAsync(Guid id);

        Task AddAsync(Category category);

        void Update(Category category);

        Task DeleteAsync(Guid id);

        Task SaveAsync();
    }
}
