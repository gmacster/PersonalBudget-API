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

        public DbSet<Category> Category { get; set; }

        public DbSet<MasterCategory> MasterCategory { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasOne(t => t.Category).WithMany().HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Category>()
                .HasOne(c => c.MasterCategory)
                .WithMany(mc => mc.Categories)
                .HasForeignKey(c => c.MasterCategoryId)
                .IsRequired();
        }
    }
}