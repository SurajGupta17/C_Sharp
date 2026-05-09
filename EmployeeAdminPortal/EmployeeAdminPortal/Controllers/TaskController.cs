//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EmployeeAdminPortal.Services;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Models;


namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices taskServices;
        public TaskController(ITaskServices taskServices)
        {
            this.taskServices = taskServices;
        }

        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            return Ok(taskServices.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var task = taskServices.GetById(id);
            if(task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Add(AddTaskDTO addtaskDTO)
        {
            var addedtask = taskServices.Add(addtaskDTO);
            return Ok(addedtask);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var deletedTask = taskServices.Delete(id);
            if(deletedTask == null)
            {
                return NotFound();
            }
            return Ok("Task Removed Successfully");
        }
    }
}
