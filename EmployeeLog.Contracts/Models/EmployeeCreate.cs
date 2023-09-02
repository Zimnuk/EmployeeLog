using EmployeeLog.Contracts.Enums;

namespace EmployeeLog.Contracts.Models;

public record EmployeeCreate(Title Title, 
	string Email,
	List<Guid> Companies);