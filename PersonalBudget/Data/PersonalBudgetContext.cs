using Microsoft.EntityFrameworkCore;

namespace PersonalBudget.Data
{
    using PersonalBudget.Models;

    public class PersonalBudgetContext : DbContext
    {
        public PersonalBudgetContext (DbContextOptions<PersonalBudgetContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
    }
}
