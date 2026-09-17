using ePizzaHub.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ePizzaHub.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,string connectionString)
        {

            services.AddDbContext<ePizzaHub_AIDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register infrastructure services here
            // For example, you can register repositories, database contexts, etc.
            // services.AddScoped<IYourRepository, YourRepository>();
            return services;
        }
    }
}
