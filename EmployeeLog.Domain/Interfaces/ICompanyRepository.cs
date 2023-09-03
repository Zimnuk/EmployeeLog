using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces;

public interface ICompanyRepository
{
	Task<bool> CheckThatTitleIsFree(string companyName, string employeeTitle);
	Task CreateCompany(CompanyCreate companyCreate);
}