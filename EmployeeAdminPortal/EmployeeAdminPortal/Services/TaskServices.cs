using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using EmployeeAdminPortal.Repositories;

namespace EmployeeAdminPortal.Services
{
    public class TaskServices : ITaskServices
    {
        private readonly ITaskRepositories taskRepositories;
        public TaskServices(ITaskRepositories taskRepositories)
        {
            this.taskRepositories = taskRepositories;            
        }

        public List<TaskItem> GetAll()
        {
            return taskRepositories.GetAll();
        }

        public TaskItem? GetById(Guid Id)
        {
            return taskRepositories.GetById(Id);
        }

        public TaskItem Add(AddTaskDTO addTaskDTO)
        {
            var newTask = new TaskItem()
            {
                Title = addTaskDTO.Title,
                Description = addTaskDTO.Description,
                EmployeeId = addTaskDTO.EmployeeId
            };

            return taskRepositories.Add(newTask);
        }

        public bool Delete(Guid Id)
        {
            return taskRepositories.Delete(Id);
        }
    }
}
