using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortal.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Employee> GetAll()
        {
            return dbContext.employees
                .Include(e =>e.Tasks)
                .ToList();
        }

        public Employee? GetById(Guid id)
        {
            return dbContext.employees
                            .Include(e =>e.Tasks)
                            .FirstOrDefault(e =>e.Id == id);
        }

        public Employee Add(Employee employee)
        {
            dbContext.employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee? Update(Guid id, Employee employee)
        {
            var existingEmployee = dbContext.employees.Find(id);

            if (existingEmployee == null)
                return null;

            existingEmployee.name = employee.name;
            existingEmployee.email = employee.email;
            existingEmployee.phone = employee.phone;
            existingEmployee.salary = employee.salary;

            dbContext.SaveChanges();
            return existingEmployee;
        }

        public bool Delete(Guid id)
        {
            var employee = dbContext.employees.Find(id);

            if (employee == null)
                return false;

            dbContext.employees.Remove(employee);
            dbContext.SaveChanges();
            return true;
        }
    }
}