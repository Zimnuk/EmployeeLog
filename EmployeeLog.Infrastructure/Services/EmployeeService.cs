using System.Text.Json;
using EmployeeLog.Contracts.Enums;
using EmployeeLog.Contracts.Models;
using EmployeeLog.Domain.Exceptions;
using EmployeeLog.Domain.Interfaces.Repositories;
using EmployeeLog.Domain.Interfaces.Services;

namespace EmployeeLog.Infrastructure.Services;

public class EmployeeService:IEmployeeService
{
	private readonly IEmployeeRepository _employeeRepository;
	private readonly ISystemLogRepository _systemLogRepository;

	public EmployeeService(IEmployeeRepository employeeRepository, ISystemLogRepository systemLogRepository) {
		_employeeRepository = employeeRepository;
		_systemLogRepository = systemLogRepository;
	}

	public async Task<Employee> GetEmployee(Guid id) {
		return  await _employeeRepository.GetEmployee(id);
	}

	public bool EmailIsUniq(string email) {
		if (_employeeRepository.EmailIsUniq(email))
			return true;
		throw new EmployeeWithEmailExistsException();
	}

	public async Task<Employee> CreateEmployee(EmployeeCreate employer) {
		var result =  await _employeeRepository.CreateEmployee(employer);
		
		var attributes = JsonSerializer.Serialize(employer);
		var comment = "new employee is created";
		
		await _systemLogRepository.WriteLog(ResourceType.Employee, Event.Create, attributes, comment);
		
		return result;
	}
}