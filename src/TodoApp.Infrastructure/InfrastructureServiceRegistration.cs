using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoApp.Core.Interfaces;
using TodoApp.Infrastructure.Persistence;
using TodoApp.Infrastructure.Repositories;

namespace TodoApp.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register database services
            services.AddSingleton<DatabaseConnectionFactory>();
            services.AddSingleton<DatabaseInitializer>();
            
            // Register repository
            services.AddScoped<ITodoRepository, DapperTodoRepository>();
            
            return services;
        }
    }
}