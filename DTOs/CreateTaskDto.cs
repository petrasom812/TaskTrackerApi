using System.ComponentModel.DataAnnotations;

namespace TaskTrackerApi.DTOs
{
    public class CreateTaskDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string title {get; set;} = string.Empty;
    }
}