using EmployeeLog.Contracts.Models;
using EmployeeLog.DB.Entities;
using EmployeeLog.DB.Extensions;
using EmployeeLog.Domain.Extensions;
using EmployeeLog.Domain.Interfaces;
using EmployeeLog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLog.DB.Repositories;

public class CompanyRepository:ICompanyRepository
{
	private readonly EmployeeDbContext _employeeDbContext;

	public CompanyRepository(EmployeeDbContext employeeDbContext) {
		_employeeDbContext = employeeDbContext;
	}

	public async Task<bool> CheckThatTitleIsFree(string companyName, string employeeTitle) {
		try
		{
			var company = await _employeeDbContext.Companies.Include(companies => companies.Employees).SingleAsync(q => q.Name == companyName);
			return company.Employees.All(q => q.Title != employeeTitle);
		}
		catch (Exception e)
		{
			throw new CompanyHasEmployeeWithThisTitleException(companyName, employeeTitle);
		}
	}

	public async Task CreateCompany(CompanyCreate companyCreate) {
		var dbModel = companyCreate.ToDbModel();
		await _employeeDbContext.Companies.AddAsync(dbModel);
		await _employeeDbContext.SaveChangesAsync();
	}
}