namespace EmployeeAdminPortal.Models.Entities
    {
        public class TaskItem
        {
            public Guid Id { get; set; }
            public required string Title { get; set; }
            public string? Description { get; set; }
            public bool IsCompleted { get; set; }

            // Foreign Key
            public Guid EmployeeId { get; set; }

            // Navigation Property
            public Employee? Employee { get; set; }
        }
    }
