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
	private readonly ICompanyRepository _companyRepository;
	public EmployeeService(IEmployeeRepository employeeRepository, ISystemLogRepository systemLogRepository, ICompanyRepository companyRepository) {
		_employeeRepository = employeeRepository;
		_systemLogRepository = systemLogRepository;
		_companyRepository = companyRepository;
	}

	public async Task<Employee> GetEmployee(Guid id) {
		return  await _employeeRepository.GetEmployee(id);
	}
	
	public async Task<bool> ValidNewEmployee(Employee employee, Guid companyId) {
		var titleIsFree = await _companyRepository.TitleIsFree(companyId, employee.Title);
		var emailIsUniq = EmailIsUniq(employee.Email);
		return titleIsFree && emailIsUniq;
	}
	
	public async Task<Employee> CreateEmployee(EmployeeCreate employee) {
		var result = await SaveEmployee(employee);
		var attributes = JsonSerializer.Serialize(employee);
		var comment = "new employee is created";
		await _systemLogRepository.WriteLog(ResourceType.Employee, Event.Create, attributes, comment);
		AddEmployeeToCompanies(employee.Companies, result);
		return result;
	}

	private async Task<Employee> SaveEmployee(EmployeeCreate employee) {
		if(EmailIsUniq(employee.Email))
			return await _employeeRepository.CreateEmployee(employee);
		throw new EmployeeWithEmailExistsException();
	}
	
	private async Task AddEmployeeToCompanies(List<Guid> companies, Employee employee) {
		foreach (var company in companies)
		{
			if(await _companyRepository.TitleIsFree(company, employee.Title))
				_companyRepository.AddEmployeesToCompany(company, new List<Guid>(){employee.Id.Value});
		}
	}
	
	private bool EmailIsUniq(string email) {
		return _employeeRepository.EmailIsUniq(email);
	}
}