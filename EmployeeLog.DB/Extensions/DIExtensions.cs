using EmployeeLog.DB.Repositories;
using EmployeeLog.Domain.Interfaces;
using EmployeeLog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeLog.DB.Extensions;

public static class DIExtensions
{
	public static IServiceCollection AddEmployeeLogDB(this IServiceCollection services, string connectionString) {
		services.AddEntityFrameworkNpgsql()
			.AddDbContext<EmployeeDbContext>(options =>
				options.UseNpgsql(connectionString));
		services.AddTransient<IEmployeeRepository, EmployeeRepository>();
		services.AddTransient<ICompanyRepository, CompanyRepository>();
		services.AddTransient<ISystemLogRepository, SystemLogRepository>();
		return services;
	}
}