using EmployeeLog.Contracts.Enums;
using EmployeeLog.DB.Entities;
using EmployeeLog.Domain.Interfaces;
using EmployeeLog.Domain.Interfaces.Repositories;

namespace EmployeeLog.DB.Repositories;

public class SystemLogRepository:ISystemLogRepository
{
	private readonly EmployeeDbContext _employeeDbContext;

	public SystemLogRepository(EmployeeDbContext employeeDbContext) {
		_employeeDbContext = employeeDbContext;
	}

	public async Task WriteLog(ResourceType resourceType, Event eventName, string resourceAttributes, string comment) {
		var log = new SystemLogs()
		{
			ResourceType = resourceType.ToString(),
			Event = eventName.ToString(),
			ResourceAttribute = resourceAttributes,
			Comment = comment
		};
		_employeeDbContext.SystemLogs.Add(log);
		await _employeeDbContext.SaveChangesAsync();
	}
}