using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTracker.WebApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string CategoryName { get; set; }
        public ICollection<TaskItem>? Tasks { get; set; }
    }
}
