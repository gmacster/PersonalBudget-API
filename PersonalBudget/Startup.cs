using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using PersonalBudget.Data.DataAccessLayer;
using PersonalBudget.Utilities;

namespace PersonalBudget
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddDbContext<PersonalBudgetContext>(
                    options => options.UseSqlServer(Configuration.GetConnectionString("PersonalBudgetContext")))
                .AddUnitOfWork<PersonalBudgetContext>();

            services.AddTransient<IImporter, YNABCsvImporter>();
        }
    }
}