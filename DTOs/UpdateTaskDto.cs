using System.ComponentModel.DataAnnotations;

namespace TaskTrackerApi.DTOs
{
    public class UpdateTaskDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string title {get; set;} = string.Empty;
        public bool IsCompleted {get; set;}
    }
}