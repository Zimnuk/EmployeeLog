using EmployeeLog.DB.Extensions;
using EmployeeLog.Domain.Interfaces.Services;
using EmployeeLog.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeLog.Infrastructurecture.Extensions;

public static class DIExtensions
{
	public static IServiceCollection AddEmployeeServices(this IServiceCollection services, string connectionString) {
		services.AddEmployeeLogDB(connectionString);
		services.AddScoped<IEmployeeService, EmployeeService>();
		services.AddScoped<ICompanyService, CompanyService>();
		return services;
	}
	
}