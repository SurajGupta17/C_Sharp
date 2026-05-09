using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repositories;

namespace EmployeeAdminPortal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public List<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public Employee? GetById(Guid id)
        {
            return employeeRepository.GetById(id);
        }

        public Employee Add(AddEmployeeDTO addEmployeeDTO)
        {
            var employee = new Employee()
            {
                name = addEmployeeDTO.name,
                email = addEmployeeDTO.email,
                phone = addEmployeeDTO.phone,
                salary = addEmployeeDTO.salary
            };

            return employeeRepository.Add(employee);
        }

        public Employee? Update(Guid id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = new Employee()
            {
                name = updateEmployeeDTO.name,
                email = updateEmployeeDTO.email,
                phone = updateEmployeeDTO.phone,
                salary = updateEmployeeDTO.salary
            };

            return employeeRepository.Update(id, employee);
        }

        public bool Delete(Guid id)
        {
            return employeeRepository.Delete(id);
        }
    }
}