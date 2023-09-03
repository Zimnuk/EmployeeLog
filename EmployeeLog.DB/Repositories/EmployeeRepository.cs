using EmployeeLog.Contracts.Models;
using EmployeeLog.DB.Extensions;
using EmployeeLog.Domain.Extensions;
using EmployeeLog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLog.DB.Repositories;

public class EmployeeRepository:IEmployeeRepository
{
	private readonly EmployeeDbContext _employeeDbContext;

	public EmployeeRepository(EmployeeDbContext employeeDbContext) {
		_employeeDbContext = employeeDbContext;
	}

	public async Task<Employee> GetEmployee(Guid id) {
		try
		{
			var dbModel =  await _employeeDbContext.Employees.SingleAsync(q => q.Id == id);
			return dbModel.ToJsonModel();
		}
		catch (Exception e)
		{
			throw new EmployeeWithIdDoesntExistsException(id);
		}

	}

	public bool EmailIsUniq(string email) {
		return _employeeDbContext.Employees.All(q => q.Email != email);
	}

	public async Task<Employee> CreateEmployee(EmployeeCreate employer) {
		var dbModel = employer.ToDbModel();
		_employeeDbContext.Employees.Add(dbModel);
		await _employeeDbContext.SaveChangesAsync();
		return dbModel.ToJsonModel();
	}
}