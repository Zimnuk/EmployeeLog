using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeLog.DB.Extensions;

public static class DIExtensions
{
	public static IServiceCollection AddEmployeeLogDB(this IServiceCollection services, string connectionString) {
		services.AddEntityFrameworkNpgsql()
			.AddDbContext<EmployeeDbContext>(options =>
				options.UseNpgsql(connectionString));
		return services;
	}
}