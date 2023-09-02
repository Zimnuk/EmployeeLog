using EmployeeLog.Contracts.Enums;

namespace EmployeeLog.Contracts.Models;

public record Employee(
	Guid Id,
	Title Title, 
	string Email,
	DateTime CreatedAt);