using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PersonalBudget.Data.DataAccessLayer;

namespace PersonalBudget.YNABImporter
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            
            Configuration = builder.Build();
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PersonalBudgetContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("PersonalBudgetContext")));
        }
    }
}