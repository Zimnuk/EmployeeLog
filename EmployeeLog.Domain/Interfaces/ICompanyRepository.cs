using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces;

public interface ICompanyRepository
{
	Task CreateCompany(CompanyCreate companyCreate);
}