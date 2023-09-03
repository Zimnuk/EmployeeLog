using EmployeeLog.Contracts.Models;
using EmployeeLog.DB.Entities;

namespace EmployeeLog.DB.Extensions;

public static class EmployeeExtensions
{
	public static Employees ToDbModel(this EmployeeCreate employee) => new Employees(){ 
		Id = Guid.NewGuid(), 
		Title = employee.Title, 
		Email = employee.Email,
		CreatedAt = DateTime.UtcNow
		
	};

	public static Employees ToDbModel(this Employee employee) => new Employees()
	{
		Id = Guid.NewGuid(),
		Title = employee.Title,
		Email = employee.Email,
		CreatedAt = DateTime.UtcNow
	};

	public static Employee ToJsonModel(this Employees employees) => new Employee(
		employees.Id, 
		employees.Title,
		employees.Email, 
		employees.CreatedAt
		);

}