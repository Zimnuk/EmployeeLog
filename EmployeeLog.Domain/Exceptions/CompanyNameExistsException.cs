namespace EmployeeLog.Domain.Exceptions;

public class CompanyNameExistsException:Exception
{
	public CompanyNameExistsException() : base(
		$"Company with this name already exists") {
		
	}
}