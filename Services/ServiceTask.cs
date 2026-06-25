using System;
using TaskTrackerApi.Data;
using TaskTrackerApi.Models;

namespace TaskTrackerApi.Services
{
    public class ServiceTask
    {
        private readonly AppDbContext _context;

        public ServiceTask(AppDbContext context)
        {
            _context = context;
        }

        //GET Method: Get All data or SELECT * FROM table_name
        public List<TaskItem> GetTasks()
        {
            return _context.Tasks.ToList();
        }
        
        //POST Method: Insert or INSERT INTO table_name (col1, col2, col3) values (value1, value2, value3)
        public TaskItem AddTask(string title)
        {
            var task = new TaskItem
            {
                Title = title,
                IsCompleted = false
            };
            _context.Tasks.Add(task);
            _context.SaveChanges();

            return task;
        }
        //PUT Method: Update or UPDATE table_name SET col1 = value1, col2 = value2 WHERE condition
        public bool UpdateTask(int id, string title, bool isCompleted)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if(task == null)
                return false;
            
            task.Title = title;
            task.IsCompleted = isCompleted;
            return true;
        }

        //DELETE Method: Delete or DELETE FROM table_name WHERE condition
        public bool DeleteTask(int id)
        {
            var task = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if(task == null)
                return false;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
    }
}