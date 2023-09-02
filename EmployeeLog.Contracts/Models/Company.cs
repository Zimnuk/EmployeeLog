namespace EmployeeLog.Contracts.Models;

public record Company(
	Guid Id,
	string Name,
	DateTime CreatedAt);