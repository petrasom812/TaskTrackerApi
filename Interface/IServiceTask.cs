using TaskTrackerApi.DTOs;

namespace TaskTrackerApi.Interface
{
    public interface IServiceTask
    {
        Task<List<GetTaskDto>> GetTasksAsync();
        Task<GetTaskDto> AddTaskAsync(string title);
        Task<bool> UpdateTaskAsync(int id, string title, bool isCompleted);
        Task<bool> DeleteTaskAsync(int id);
    }
}