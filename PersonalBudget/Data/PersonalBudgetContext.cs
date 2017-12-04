﻿using Microsoft.EntityFrameworkCore;

using PersonalBudget.Models;

namespace PersonalBudget.Data
{
    public class PersonalBudgetContext : DbContext
    {
        public PersonalBudgetContext(DbContextOptions<PersonalBudgetContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }

        public DbSet<Transaction> Transaction { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasOne(t => t.Category).WithMany();
        }
    }
}