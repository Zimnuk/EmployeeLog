namespace EmployeeLog.Domain.Extensions;

public class EmployeeWithEmailExistsException:Exception
{
	public EmployeeWithEmailExistsException():base("Employee with this email already exists") {
		
	}
}