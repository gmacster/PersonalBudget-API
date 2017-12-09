using System.IO;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PersonalBudget.Data.DataAccessLayer
{
    public sealed class PersonalBudgetContextFactory : IDesignTimeDbContextFactory<PersonalBudgetDbContext>
    {
        public PersonalBudgetContextFactory()
        {
            this.Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public PersonalBudgetContextFactory(IConfiguration configuration)
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
