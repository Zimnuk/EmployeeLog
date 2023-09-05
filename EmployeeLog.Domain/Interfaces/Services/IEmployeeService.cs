using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Services;

public interface IEmployeeService
{
	Task<Employee> GetEmployee(Guid id);
	Task<bool> ValidNewEmployee(Employee employee, Guid companyId);
	Task<Employee> CreateEmployee(EmployeeCreate employee);
}