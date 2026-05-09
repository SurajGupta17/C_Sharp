using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
//using EmployeeAdminPortal.Repositories;

namespace EmployeeAdminPortal.Repositories
{
    public class TaskRepositories : ITaskRepositories
    {
        private readonly ApplicationDbContext dbContext;

        public TaskRepositories(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<TaskItem> GetAll()
        {
            return dbContext.Tasks
                .Include(t=> t.Employee)
                .ToList();
        }
        public TaskItem? GetById(Guid id)
        {
            return dbContext.Tasks
                .Include(t => t.Employee)
                .FirstOrDefault(t=> t.Id == id);
        }

        public TaskItem Add(TaskItem newTask)
        {
            dbContext.Tasks.Add(newTask);
            dbContext.SaveChanges();
            return (newTask);
        }

        public bool Delete(Guid id)
        {
            var taskToRemove = dbContext.Tasks.Find(id);

            if(taskToRemove == null)
            {
                return false;
            }

            dbContext.Tasks.Remove(taskToRemove);
            dbContext.SaveChanges();
            return true;
        }
    }
}
