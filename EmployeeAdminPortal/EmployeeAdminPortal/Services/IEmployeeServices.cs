using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAll(int page, int pagesize, string search);
        Employee? GetById(Guid id);
        Employee Add(AddEmployeeDTO addEmployeeDTO);
        Employee? Update(Guid id, UpdateEmployeeDTO updateEmployeeDTO);
        bool Delete(Guid id);
    }
}