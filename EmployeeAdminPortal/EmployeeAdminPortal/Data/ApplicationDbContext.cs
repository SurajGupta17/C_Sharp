using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> employees { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }

    }
}
