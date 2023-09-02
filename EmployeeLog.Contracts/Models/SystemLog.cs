using EmployeeLog.Contracts.Enums;

namespace EmployeeLog.Contracts.Models;

public record SystemLog(
	string ResourceType,
	DateTime CreatedAt, 
	Event Event,
	string ResourceAttribute,
	string Comment
	);