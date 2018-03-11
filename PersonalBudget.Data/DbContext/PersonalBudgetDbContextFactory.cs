using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PersonalBudget.Data.DbContext
{
    public sealed class PersonalBudgetDbContextFactory : IDesignTimeDbContextFactory<PersonalBudgetDbContext>
    {
        public PersonalBudgetDbContextFactory()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public PersonalBudgetDbContextFactory(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public PersonalBudgetDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PersonalBudgetDbContext>();

            var connectionString = this.Configuration.GetConnectionString("PersonalBudgetContext");

            builder.UseSqlServer(connectionString);

            return new PersonalBudgetDbContext(builder.Options);
        }
    }
}
