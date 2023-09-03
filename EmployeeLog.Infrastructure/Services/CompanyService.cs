using EmployeeLog.Contracts.Enums;
using EmployeeLog.Contracts.Models;
using EmployeeLog.Domain.Interfaces.Repositories;
using EmployeeLog.Domain.Interfaces.Services;

namespace EmployeeLog.Infrastructure.Services;

public class CompanyService:ICompanyService
{
	private readonly ICompanyRepository _companyRepository;
	private readonly ISystemLogRepository _systemLogRepository;
	private readonly IEmployeeService _employeeService;
	public CompanyService(ICompanyRepository companyRepository, ISystemLogRepository systemLogRepository, IEmployeeService employeeService) {
		_companyRepository = companyRepository;
		_systemLogRepository = systemLogRepository;
		_employeeService = employeeService;
	}
	
	public async Task CreateCompany(CompanyCreate companyCreate, CancellationToken cancellationToken) {
		var company = await _companyRepository.CreateCompany(companyCreate);
		var companyComment = "Company created";
		_systemLogRepository.WriteLog(ResourceType.Company, Event.Create, companyCreate.Name, companyComment);
		var employees = new List<Guid>();
		foreach (var employee in companyCreate.Employees)
		{
			if (employee.Id != null)
			{
				var dbEmployee = await _employeeService.GetEmployee(employee.Id);
				if(await _companyRepository.TitleIsFree(company.Name, dbEmployee.Title))
					employees.Add(dbEmployee.Id);
			}
			else
			{
				if (!await ValidNewEmployee(employee, company.Name)) continue;
				var newEmployee= await CreateEmployee(employee);
				employees.Add(newEmployee.Id);
			}
		}
		await _companyRepository.AddEmployeesToCompany(company.Id, employees);
	}

	private async Task<bool> ValidNewEmployee(Employee employee, string companyName) {
		var titleIsFree = await _companyRepository.TitleIsFree(companyName, employee.Title);
		var emailIsUniq = _employeeService.EmailIsUniq(employee.Email);
		return titleIsFree && emailIsUniq;
	}

	private async Task<Employee> CreateEmployee(Employee employee) {
		var newEmployee = new EmployeeCreate(employee.Title, employee.Email);
		return await _employeeService.CreateEmployee(newEmployee);
	}
}