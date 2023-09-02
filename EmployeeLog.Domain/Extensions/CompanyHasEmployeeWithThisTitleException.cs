namespace EmployeeLog.Domain.Extensions;

public class CompanyHasEmployeeWithThisTitleException:Exception
{
	public CompanyHasEmployeeWithThisTitleException(string companyName, string title) : base(
		$"Company '{companyName}' already has employee in title {title}") {
		
	}
}