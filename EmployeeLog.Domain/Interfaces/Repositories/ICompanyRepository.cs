using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Repositories;

public interface ICompanyRepository
{
	Task<bool> CheckThatTitleIsFree(string companyName, string employeeTitle);
	Task CreateCompany(CompanyCreate companyCreate);
}