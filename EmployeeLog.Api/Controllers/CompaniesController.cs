using EmployeeLog.Contracts.Models;
using EmployeeLog.Domain.Interfaces.Services;
using EmployeeLog.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLog.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController:ControllerBase
{
	private readonly ICompanyService _companyService;

	public CompaniesController(ICompanyService companyService) {
		_companyService = companyService;
	}

	[HttpPost]
	public async Task<IActionResult> CreateCompany([FromBody] CompanyCreate companyCreate) {
		try
		{
			var result = await _companyService.CreateCompany(companyCreate);
			return StatusCode(201, result);
		}
		catch (Exception e)
		{
			return StatusCode(400, e.Message);
		}
	}
}