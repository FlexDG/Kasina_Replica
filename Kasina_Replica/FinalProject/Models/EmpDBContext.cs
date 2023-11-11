using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace FinalProject.Models
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options)

        {

        }

        //table name: Employees
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Designation> Designations { get; set; }

    }
}
