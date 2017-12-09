using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using PersonalBudget.Data.DataAccessLayer;

namespace PersonalBudget.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonalBudgetContext(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddTransient<IDesignTimeDbContextFactory<PersonalBudgetDbContext>, PersonalBudgetContextFactory>()
                .AddTransient(
                    provider =>
                    {
                        var factory = provider.GetService<IDesignTimeDbContextFactory<PersonalBudgetDbContext>>();
                        return factory.CreateDbContext(new string[] { });
                    })
                .AddDbContext<PersonalBudgetDbContext>();
        }
    }
}
