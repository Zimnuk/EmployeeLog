using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Services;

public interface IEmployeeService
{
	Task<Employee> GetEmployee(Guid id);
	bool EmailIsUniq(string email);
	Task<Employee> CreateEmployee(EmployeeCreate employer);
}