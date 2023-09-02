namespace EmployeeLog.Domain.Extensions;

public class EmployeeWithIdDoesntExistsException:Exception
{
	public EmployeeWithIdDoesntExistsException(Guid id):base($"Employee with id {id} doesn't exists") {
		
	}
}