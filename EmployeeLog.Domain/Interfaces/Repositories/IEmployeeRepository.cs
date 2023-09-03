using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
	Task<Employee> GetEmployee(Guid id);
	bool EmailIsUniq(string email);
	Task<Employee> CreateEmployee(EmployeeCreate employer);
}