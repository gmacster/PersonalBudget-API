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

            var transactionEntity = modelBuilder.Entity<Transaction>();
            transactionEntity.HasOne(t => t.Category).WithMany(c => c.Transactions).HasForeignKey(t => t.CategoryId);
            transactionEntity.HasOne(t => t.Account).WithMany(a => a.Transactions).HasForeignKey(t => t.AccountId).IsRequired();

            modelBuilder.Entity<Category>()
                .HasOne(c => c.MasterCategory)
                .WithMany(mc => mc.Categories)
                .HasForeignKey(c => c.MasterCategoryId)
                .IsRequired();

            var budgetTargetEntity = modelBuilder.Entity<BudgetTarget>();
            budgetTargetEntity.HasOne(t => t.BudgetPeriod).WithMany(p => p.BudgetTargets).HasForeignKey(t => t.BudgetPeriodId).IsRequired();
            budgetTargetEntity.HasOne(t => t.Category).WithMany(c => c.BudgetTargets).HasForeignKey(t => t.CategoryId).IsRequired();
        }
    }
}