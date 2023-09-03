using EmployeeLog.Contracts.Models;
using EmployeeLog.DB.Extensions;
using EmployeeLog.Domain.Interfaces;
using EmployeeLog.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLog.DB.Repositories;

public class EmployeeRepository:IEmployeeRepository
{
	public EmployeeDbContext _EmployeeDbContext;

	public EmployeeRepository(EmployeeDbContext employeeDbContext) {
		_EmployeeDbContext = employeeDbContext;
	}

	public async Task<Employee> GetEmployee(string email) {
		var dbModel =  await _EmployeeDbContext.Employees.FirstAsync(q => q.Email == email);
		return dbModel.ToJsonModel();
	}
	public async Task<Employee> CreateEmployee(EmployeeCreate employer) {
		var dbModel = employer.ToDbModel();
		_EmployeeDbContext.Employees.Add(dbModel);
		await _EmployeeDbContext.SaveChangesAsync();
		return dbModel.ToJsonModel();
	}
}