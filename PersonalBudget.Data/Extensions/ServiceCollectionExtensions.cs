using System;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

using PersonalBudget.Data.DbContext;

namespace PersonalBudget.Data.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersonalBudgetDbContext(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            return services.AddTransient<IDesignTimeDbContextFactory<PersonalBudgetDbContext>, PersonalBudgetDbContextFactory>()
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
