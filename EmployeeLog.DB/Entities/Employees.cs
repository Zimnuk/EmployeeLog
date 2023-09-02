namespace EmployeeLog.DB.Entities;

public class Employees
{
	public Guid Id {get; set;}
	public string Title {get; set;}
	public string Email {get; set;}
	public 	DateTime CreatedAt {get; set;}
	public List<Companies>	Companies { get; } = new();
}