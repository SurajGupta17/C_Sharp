using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;

namespace EmployeeAdminPortal.Repositories
{
    public interface ITaskRepositories
    {
        List<TaskItem> GetAll();
        TaskItem? GetById(Guid id);
        TaskItem Add(TaskItem newTask);
        bool Delete(Guid id);
    }
}
