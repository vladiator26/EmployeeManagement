using EmployeeManagement.BLL.Mappers;
using EmployeeManagement.BLL.Services;
using EmployeeManagement.BLL.Services.Interfaces;
using EmployeeManagement.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeManagement.BLL
{
    public static class Startup
    {
        public static void InitBusinessLogicLayerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<EmployeeMapper>();
            services.AddTransient<PositionMapper>();
            services.InitDataAccessLayerServices(configuration);
        }
    }
}