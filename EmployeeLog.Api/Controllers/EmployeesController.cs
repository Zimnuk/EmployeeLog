using EmployeeLog.Contracts.Models;
using EmployeeLog.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController:ControllerBase
{
	private readonly IEmployeeService _employeeService;

	public EmployeesController(IEmployeeService employeeService) {
		_employeeService = employeeService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateEmployee([FromBody]EmployeeCreate employeeCreate) {
		try
		{
			var result = await _employeeService.CreateEmployee(employeeCreate);
			return StatusCode(201, result);
		}
		catch (Exception e)
		{
			return StatusCode(400, e.Message);
		}
	}
}