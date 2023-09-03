using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Repositories;

public interface ICompanyRepository
{
	Task<bool> TitleIsFree(string companyName, string employeeTitle);
	Task<Company> CreateCompany(CompanyCreate companyCreate);
	Task AddEmployeesToCompany(Guid companyId, List<Guid> employeeIds);
}