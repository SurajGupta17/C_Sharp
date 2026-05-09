using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Services;  

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var employees = employeeService.GetAll();
            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = employeeService.GetById(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {

            var addedEmployee = employeeService.Add(addEmployeeDTO);
            return Ok(addedEmployee);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDTO updateEmployeeDTO)
        { 

            var updatedEmployee = employeeService.Update(id, updateEmployeeDTO);
            if (updatedEmployee == null)
                return NotFound();
            return Ok(updatedEmployee);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var result = employeeService.Delete(id);
            if (!result)
                return NotFound();
            return Ok("Employee deleted successfully");
        }
    }
}