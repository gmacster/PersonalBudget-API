using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.DataAccessLayer
{
    public class PersonalBudgetContext : DbContext
    {
        public PersonalBudgetContext(DbContextOptions<PersonalBudgetContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var transactionEntity = modelBuilder.Entity<Transaction>();
            transactionEntity.HasOne(t => t.Category).WithMany(c => c.Transactions).HasForeignKey(t => t.CategoryId);
            transactionEntity.HasOne(t => t.Account).WithMany(a => a.Transactions).HasForeignKey(t => t.AccountId).IsRequired();
            modelBuilder.Entity<Category>()
                .HasOne(c => c.MasterCategory)
                .WithMany(mc => mc.Categories)
                .HasForeignKey(c => c.MasterCategoryId)
                .IsRequired();
        }
    }
}