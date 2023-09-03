using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Services;

public interface ICompanyService
{
	Task CreateCompany(CompanyCreate companyCreate, CancellationToken cancellationToken);
}