namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        
        public required string name { get; set; }

        public required string email { get; set; }
        public string? phone { get; set; }
        public decimal salary { get; set; }
        public ICollection<TaskItem>? Tasks { get; set; }
    }
}
