﻿using EmployeeLog.Contracts.Models;

namespace EmployeeLog.Domain.Interfaces.Services;

public interface ICompanyService
{
	Task<Company> CreateCompany(CompanyCreate companyCreate);
}