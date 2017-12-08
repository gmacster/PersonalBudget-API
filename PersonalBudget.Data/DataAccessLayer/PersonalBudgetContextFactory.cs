using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PersonalBudget.Data.DataAccessLayer
{
    public sealed class PersonalBudgetContextFactory : IDesignTimeDbContextFactory<PersonalBudgetContext>
    {
        public PersonalBudgetContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<PersonalBudgetContext>();

            var connectionString = configuration.GetConnectionString("PersonalBudgetContext");

            builder.UseSqlServer(connectionString);

            return new PersonalBudgetContext(builder.Options);
        }
    }
}
