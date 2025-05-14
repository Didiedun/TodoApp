using Microsoft.EntityFrameworkCore;
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));
            
            services.AddScoped<ITodoRepository, TodoRepository>();
            
            return services;
        }
    }
}