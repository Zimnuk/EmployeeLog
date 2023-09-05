using EmployeeLog.Contracts.Models;
using EmployeeLog.DB.Extensions;
using EmployeeLog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLog.DB.Repositories;

public class CompanyRepository:ICompanyRepository
{
	private readonly EmployeeDbContext _employeeDbContext;

	public CompanyRepository(EmployeeDbContext employeeDbContext) {
		_employeeDbContext = employeeDbContext;
	}

	public async Task<bool> TitleIsFree(Guid companyId, string employeeTitle) {
		var company = await _employeeDbContext.Companies.Include(companies => companies.Employees)
			.SingleAsync(q => q.Id == companyId);
		return company.Employees.All(q => q.Title != employeeTitle);

	}

	public async Task<bool> CompanyNameIsUniq(string companyName) {
		return await _employeeDbContext.Companies.AllAsync(q => q.Name!= companyName);
	}

	public async Task<Company> CreateCompany(CompanyCreate companyCreate) {
		var dbModel = companyCreate.ToDbModel();
		await _employeeDbContext.Companies.AddAsync(dbModel);
		await _employeeDbContext.SaveChangesAsync();
		return dbModel.ToJsonModel();
	}

	public async Task AddEmployeesToCompany(Guid companyId, List<Guid> employeeIds) {
		var company = await _employeeDbContext.Companies.SingleAsync(q => q.Id == companyId);
		foreach (var id in employeeIds)
		{
			var dbEmployee = await _employeeDbContext.Employees.SingleAsync();
			company.Employees.Add(dbEmployee);
		}
		await _employeeDbContext.SaveChangesAsync();
	}
}