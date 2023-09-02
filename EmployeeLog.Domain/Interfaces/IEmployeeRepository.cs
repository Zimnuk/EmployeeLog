using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces;

public interface IEmployeeRepository
{
	Task<Employee> GetEmployee(string Email);
	Task<Employee> CreateEmployee(EmployeeCreate employer);
}