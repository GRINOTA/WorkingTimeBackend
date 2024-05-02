using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WorkingTime.Application.Interfaces;

namespace WorkingTime.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<WorkingTimeDbContext>(options =>
            {
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });
            services.AddScoped<IWorkingTimeDbContext>(provider => provider.GetService<WorkingTimeDbContext>());
            return services;
        }
    }
}
