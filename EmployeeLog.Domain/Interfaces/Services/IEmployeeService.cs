using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Services;

public interface IEmployeeService
{
	Task<Employee> GetEmployee(string Email);
	Task<Employee> CreateEmployee(EmployeeCreate employer);
}