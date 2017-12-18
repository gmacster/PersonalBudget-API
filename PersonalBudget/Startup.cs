using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

using PersonalBudget.Data.DataAccessLayer;
using PersonalBudget.Data.Extensions;

namespace PersonalBudget
{
    public class Startup
    {
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

            services.AddPersonalBudgetContext().AddUnitOfWork<PersonalBudgetDbContext>();
        }
    }
}