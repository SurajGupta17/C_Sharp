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
    public class TaskController : ControllerBase
    {
        private readonly ITaskServices taskServices;
        public TaskController(ITaskServices taskServices)
        {
            this.taskServices = taskServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public IActionResult GetAllTask()
        {
            return Ok(taskServices.GetAll());
        }

        [HttpGet]
        [Route("{id:guid}")]
        [Authorize(Roles = "Admin,Manager,Employee")]
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
        [Authorize(Roles = "Manager,Employee")]
        public IActionResult Add(AddTaskDTO addtaskDTO)
        {
            var addedtask = taskServices.Add(addtaskDTO);
            return Ok(addedtask);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize (Roles = "Manager,Admin")]
        public IActionResult Delete(Guid id)
        {
            var deletedTask = taskServices.Delete(id);
        
            return Ok("Task Removed Successfully");
        }
    }
}
