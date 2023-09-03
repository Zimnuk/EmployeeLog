using EmployeeLog.Contracts.Enums;

namespace EmployeeLog.Domain.Interfaces.Repositories;

public interface ISystemLogRepository
{
	Task WriteLog(string resourceType, Event eventName, string resourceAttributes, string comment);
}