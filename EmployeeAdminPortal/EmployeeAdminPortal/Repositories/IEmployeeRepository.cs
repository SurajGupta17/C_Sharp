using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll(int page,int pagesize,string search);
        Employee? GetById(Guid id);
        Employee Add(Employee employee);
        Employee? Update(Guid id, Employee employee);
        bool Delete(Guid id);
    }
}
