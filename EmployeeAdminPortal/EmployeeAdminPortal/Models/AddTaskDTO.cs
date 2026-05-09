namespace EmployeeAdminPortal.Models
{
    public class AddTaskDTO
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
