using System;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualBasic;
using TaskTrackerApi.Models;

namespace TaskTrackerApi.Services
{
    public class ServiceTask
    {
        private List<TaskItem> tasks = new ();

        //GET Method: Get All data or SELECT * FROM table_name
        public List<TaskItem> GetTasks()
        {
            return tasks.ToList();
        }
        
        //POST Method: Insert or INSERT INTO table_name (col1, col2, col3) values (value1, value2, value3)
        public TaskItem AddTask(string title)
        {
            var task = new TaskItem
            {
                Id = tasks.Count + 1,
                Title = title,
                IsCompleted = false
            };
            tasks.Add(task);
            return task;
        }
        //PUT Method: Update or UPDATE table_name SET col1 = value1, col2 = value2 WHERE condition
        public bool UpdateTask(int id, string title, bool isCompleted)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if(task == null)
                return false;
            
            task.Title = title;
            task.IsCompleted = isCompleted;
            return true;
        }

        //DELETE Method: Delete or DELETE FROM table_name WHERE condition
        public bool DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);

            if(task == null)
                return false;

            tasks.Remove(task);
            return true;
        }
    }
}