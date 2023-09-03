namespace EmployeeLog.Domain.Exceptions;

public class EmployeeWithEmailExistsException:Exception
{
	public EmployeeWithEmailExistsException():base("Employee with this email already exists") {
		
	}
}