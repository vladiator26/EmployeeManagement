using EmployeeManagement.DAL.AppContext;
using EmployeeManagement.DAL.Repositories;
using EmployeeManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.DAL
{
    public static class Startup
    {
        public static void InitDataAccessLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Transient);

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IPositionRepository, PositionRepository>();
        }
    }
}