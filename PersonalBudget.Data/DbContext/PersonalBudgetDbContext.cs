using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.Data.DbContext
{
    public class PersonalBudgetDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public PersonalBudgetDbContext(DbContextOptions<PersonalBudgetDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var budget = modelBuilder.Entity<Budget>();
            budget.HasMany(b => b.MasterCategories).WithOne(mc => mc.Budget).HasForeignKey(mc => mc.BudgetId).IsRequired();
            budget.HasMany(b => b.Accounts).WithOne(a => a.Budget).HasForeignKey(a => a.BudgetId).IsRequired();
            budget.HasMany(b => b.BudgetPeriods).WithOne(p => p.Budget).HasForeignKey(p => p.BudgetId).IsRequired();

            modelBuilder.Entity<MasterCategory>()
                .HasMany(mc => mc.Categories)
                .WithOne(c => c.MasterCategory)
                .HasForeignKey(c => c.MasterCategoryId)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId)
                .IsRequired();

            modelBuilder.Entity<BudgetPeriod>()
                .HasMany(p => p.BudgetTargets)
                .WithOne(t => t.BudgetPeriod)
                .HasForeignKey(t => t.BudgetPeriodId)
                .IsRequired();

            var categoryEntity = modelBuilder.Entity<Category>();

            categoryEntity.HasMany(c => c.Transactions)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired(false);

            categoryEntity.HasMany(c => c.BudgetTargets)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .IsRequired(false);
        }
    }
}