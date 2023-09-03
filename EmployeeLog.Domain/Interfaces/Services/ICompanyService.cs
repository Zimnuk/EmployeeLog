using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Services;

public interface ICompanyService
{
	Task<bool> CheckThatTitleIsFree(string companyName, string employeeTitle);
	Task CreateCompany(CompanyCreate companyCreate);
}