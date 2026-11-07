
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Models;

namespace EmployeeManagement.Data;

public class EmployeeManagementContext : DbContext
{
    public EmployeeManagementContext(
        DbContextOptions<EmployeeManagementContext> options)
        : base(options)
    {
        
    }

    public DbSet<Employee> Employees { get; set; }
}
