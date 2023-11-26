using Employee_CRUD_App.Models;
using System.Data.Entity;

namespace Employee_CRUD_App.Controllers
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("DefaultConnection")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}