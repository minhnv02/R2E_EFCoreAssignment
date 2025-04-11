using Microsoft.Extensions.DependencyInjection;
using Rookies_EFCoreAssignment.Application.Services.ImPl;
using Rookies_EFCoreAssignment.Application.Services;

namespace Rookies_EFCoreAssignment.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<IProjectEmployeeService, ProjectEmployeeService>();
        }
    }
}
