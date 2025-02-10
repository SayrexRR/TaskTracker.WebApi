using System.ComponentModel.DataAnnotations;

namespace TaskTracker.WebApi.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string ProjectName { get; set; }
        public string? Description { get; set; }
        public ICollection<TaskItem>? TaskItems { get; set; }
        public ICollection<ApplicationUser>? Users { get; set; }
    }
}
