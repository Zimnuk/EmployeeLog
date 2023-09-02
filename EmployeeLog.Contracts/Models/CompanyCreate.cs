namespace EmployeeLog.Contracts.Models;

public record CompanyCreate(
	string Name,
	List<Employee> Employees
	);