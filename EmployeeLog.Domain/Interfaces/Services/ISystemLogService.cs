using EmployeeLog.Contracts.Enums;

namespace EmployeeLog.Domain.Interfaces.Services;

public interface ISystemLogService
{
	Task WriteMessage(string resourceType, Event eventName, string resourceAttributes, string comment);
}