using EmployeeLog.DB.Repositories;
using EmployeeLog.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeLog.DB.Extensions;

public static class DIExtensions
{
	public static IServiceCollection AddEmployeeLogDB(this IServiceCollection services, string connectionString) {
		services.AddEntityFrameworkNpgsql()
			.AddDbContext<EmployeeDbContext>(options =>
				options.UseNpgsql(connectionString));
		services.AddScoped<IEmployeeRepository, EmployeeRepository>();
		services.AddScoped<ICompanyRepository, CompanyRepository>();
		services.AddScoped<ISystemLogRepository, SystemLogRepository>();
		return services;
	}
}