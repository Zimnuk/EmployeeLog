using EmployeeLog.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeLog.DB;

public class EmployeeDbContext:DbContext
{	
	public virtual DbSet<Employees> Employees { get; set; }
	public virtual DbSet<Companies> Companies { get; set; }
	public virtual DbSet<SystemLogs> SystemLogs { get; set; }
}