using Microsoft.AspNetCore.Mvc;
using TaskTrackerApi.DTOs;
using TaskTrackerApi.Services;

namespace TaskTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ServiceTask _service;
        public TaskController(ServiceTask service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _service.GetTasks();
            return Ok(tasks);
        }
        [HttpPost]
        public IActionResult Post(CreateTaskDto dto)
        {
            var task = _service.AddTask(dto.title);
            return Ok(task);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateTaskDto dto)
        {
            var result = _service.UpdateTask(id, dto.title, dto.IsCompleted);
            if (!result)
            {
                return NotFound("Task not found");
            }
            return Ok("Task marked as completed");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.DeleteTask(id);
            if(!result)
                return NotFound("Task not found");
            return NoContent();
        }

    }
}