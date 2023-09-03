using EmployeeLog.Contracts.Models;
using EmployeeLog.DB.Entities;

namespace EmployeeLog.DB.Extensions;

public static class CompanyExtensions
{
	public static Companies ToDbModel(this CompanyCreate companyCreate) => new Companies()
	{
		Id = new Guid(),
		Name = companyCreate.Name,
		CreatedAt = DateTime.UtcNow
	};

	public static Companies ToDbModel(this Company company) => new Companies()
	{
		Id = company.Id,
		Name = company.Name,
		CreatedAt = company.CreatedAt
	};

	public static Company ToJsonModel(this Companies company) => new Company(
			company.Id, 
			company.Name,
			company.CreatedAt
			);
}