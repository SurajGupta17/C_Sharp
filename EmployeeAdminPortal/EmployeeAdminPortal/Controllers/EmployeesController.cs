using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = employeeRepository.GetById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var employee = new Employee()
            {
                name = addEmployeeDTO.name,
                email = addEmployeeDTO.email,
                phone = addEmployeeDTO.phone,
                salary = addEmployeeDTO.salary
            };

            var addedEmployee = employeeRepository.Add(employee);
            return Ok(addedEmployee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = new Employee()
            {
                name = updateEmployeeDTO.name,
                email = updateEmployeeDTO.email,
                phone = updateEmployeeDTO.phone,
                salary = updateEmployeeDTO.salary
            };

            var updatedEmployee = employeeRepository.Update(id, employee);
            if (updatedEmployee == null)
                return NotFound();
            return Ok(updatedEmployee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var result = employeeRepository.Delete(id);
            if (!result)
                return NotFound();
            return Ok("Employee deleted successfully");
        }
    }
}