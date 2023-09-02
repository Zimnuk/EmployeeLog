namespace EmployeeLog.DB.Entities;

public class Companies
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public DateTime CreatedAt { get; set; }
	public List<Employees> Employees { get; } = new();
	
}