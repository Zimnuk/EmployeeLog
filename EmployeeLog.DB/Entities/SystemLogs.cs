namespace EmployeeLog.DB.Entities;

public class SystemLogs
{
	public long Id { get; set; }
	public string ResourceType{get; set;}
	public 	DateTime CreatedAt{get; set;}
	public string Event{get; set;}
	public string ResourceAttribute{get; set;}
	public string Comment{get; set;}
}