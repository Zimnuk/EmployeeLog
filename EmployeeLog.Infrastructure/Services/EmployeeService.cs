using EmployeeLog.Contracts.Models;
using EmployeeLog.Domain.Extensions;
using EmployeeLog.Domain.Interfaces.Repositories;
using EmployeeLog.Domain.Interfaces.Services;

namespace EmployeeLog.Infrastructure.Services;

public class EmployeeService:IEmployeeService
{
	private readonly IEmployeeRepository _employeeRepository;

	public EmployeeService(IEmployeeRepository employeeRepository) {
		_employeeRepository = employeeRepository;
	}

	public async Task<Employee> GetEmployee(Guid id) {
		return await _employeeRepository.GetEmployee(id);
	}

	public bool EmailIsUniq(string email) {
		if (_employeeRepository.EmailIsUniq(email))
			return true;
		throw new EmployeeWithEmailExistsException();
	}

	public async Task<Employee> CreateEmployee(EmployeeCreate employer) {
		return await _employeeRepository.CreateEmployee(employer);
	}
}