using EmployeeAdminPortal.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public EmployeesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            var alllEmployees = dbContext.employees.ToList();

            return Ok(alllEmployees);
        }

        [HttpGet]
        [Route("{employeeName}")]
        public IActionResult GetEmployeeByName(string employeeName)
        {
            var employee = dbContext.employees.FirstOrDefault(e=> e.name == employeeName);

            if (employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult GetEmployeeByID(Guid Id)
        {
            var employee = dbContext.employees.Find(Id);

            if(employee is null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpPut]
        [Route("{id:guid}")]
       
        public IActionResult UpdateEmployee(Guid id,UpdateEmployeeDTO updateEmployeeDTO)
        {
            var employee = dbContext.employees.Find(id);
            
            if(employee == null)
            {
                return NotFound();
            }

            employee.name = updateEmployeeDTO.name;
            employee.email = updateEmployeeDTO.email;
            employee.phone = updateEmployeeDTO.phone;
            employee.salary = updateEmployeeDTO.salary;

            dbContext.SaveChanges();
            return Ok(updateEmployeeDTO);   
        }


        [HttpPost]

        public IActionResult AddEmployee(AddEmployeeDTO addEmployeeDTO)
        {
            var emplyeeEntity = new Employee()
            {
                name = addEmployeeDTO.name,
                email = addEmployeeDTO.email,
                phone = addEmployeeDTO.phone,
                salary = addEmployeeDTO.salary
            };

            dbContext.employees.Add(emplyeeEntity);
            dbContext.SaveChanges();

            return Ok(emplyeeEntity);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = dbContext.employees.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            dbContext.employees.Remove(employee);
            dbContext.SaveChanges();

            return Ok("Employee removed Successfully");
        }
    }
}
