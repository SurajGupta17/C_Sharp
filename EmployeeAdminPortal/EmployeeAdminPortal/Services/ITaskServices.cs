using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Services
{
    public interface ITaskServices
    {
        List<TaskItem> GetAll();
        TaskItem? GetById(Guid id);

        TaskItem Add(AddTaskDTO addtaskDTO);

        bool Delete(Guid id);
     
    }
}
