namespace TaskTracker.WebApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; }
        public int? CategoryId { get; set; }
        public int? ProjectId { get; set; }
        public string? AssignedToId { get; set; }
        public Category? Category { get; set; }
        public Project? Project { get; set; }
        public ApplicationUser? AssignedTo { get; set; }
    }
}
