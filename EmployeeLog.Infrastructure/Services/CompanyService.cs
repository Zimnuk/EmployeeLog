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
	
	public async Task<Company> CreateCompany(CompanyCreate companyCreate) {
		var company = await _companyRepository.CreateCompany(companyCreate);
		var companyComment = "Company created";
		_systemLogRepository.WriteLog(ResourceType.Company, Event.Create, companyCreate.Name, companyComment);
		var employees = new List<Guid>();
		foreach (var employee in companyCreate.Employees)
		{
			if (employee.Id != null)
			{
				var dbEmployee = await _employeeService.GetEmployee(employee.Id.Value);
				if(await _companyRepository.TitleIsFree(company.Id, dbEmployee.Title))
					employees.Add(dbEmployee.Id.Value);
			}
			else
			{
				if (!await _employeeService.ValidNewEmployee(employee, company.Id)) continue;
				var newEmployee= await CreateEmployee(employee, company.Id);
				employees.Add(newEmployee.Id.Value);
			}
		}
		await _companyRepository.AddEmployeesToCompany(company.Id, employees);
		return company;
	}
	

	private async Task<Employee> CreateEmployee(Employee employee, Guid company) {
		var newEmployee = new EmployeeCreate(employee.Title, employee.Email, new List<Guid>(){company});
		return await _employeeService.CreateEmployee(newEmployee);
	}
}