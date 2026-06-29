namespace TaskTrackerApi.DTOs
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
    }
}