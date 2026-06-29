using Microsoft.EntityFrameworkCore;
using TaskTrackerApi.Data;
using TaskTrackerApi.Models;
using TaskTrackerApi.DTOs;
using TaskTrackerApi.Interface;

namespace TaskTrackerApi.Services
{
    public class ServiceTask : IServiceTask
    {
        private readonly AppDbContext _context;

        public ServiceTask(AppDbContext context)
        {
            _context = context;
        }

        //GET Method: Get All data or SELECT * FROM table_name
        public async Task<List<GetTaskDto>> GetTasksAsync()
        {
            var tasks = await _context.Tasks.ToListAsync();

            return tasks.Select(t => new GetTaskDto
            {
                Id = t.Id,
                Title = t.Title,
                IsCompleted = t.IsCompleted
            }).ToList();
        }
        
        //POST Method: Insert or INSERT INTO table_name (col1, col2, col3) values (value1, value2, value3)
        public async Task<GetTaskDto> AddTaskAsync(string title)
        {
            var task = new TaskItem
            {
                Title = title,
                IsCompleted = false
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return new GetTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                IsCompleted = task.IsCompleted
            };
        }
        //PUT Method: Update or UPDATE table_name SET col1 = value1, col2 = value2 WHERE condition
        public async Task<bool> UpdateTaskAsync(int id, string title, bool isCompleted)
        {
            var task = await _context.Tasks.FindAsync(id);

            if(task == null)
                return false;
            
            task.Title = title;
            task.IsCompleted = isCompleted;

            await _context.SaveChangesAsync();
            return true;
        }

        //DELETE Method: Delete or DELETE FROM table_name WHERE condition
        public async Task<bool> DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if(task == null)
                return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}