using EmployeeLog.Contracts.Enums;

namespace EmployeeLog.Contracts.Models;

public record Employee(
	Guid Id,
	string Title, 
	string Email,
	DateTime CreatedAt);