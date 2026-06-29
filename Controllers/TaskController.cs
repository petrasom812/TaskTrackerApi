using Microsoft.AspNetCore.Mvc;
using TaskTrackerApi.DTOs;
using TaskTrackerApi.Interface;
using TaskTrackerApi.Services;

namespace TaskTrackerApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IServiceTask _service;
        public TaskController(IServiceTask service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var tasks = await _service.GetTasksAsync();
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<ActionResult> Post(CreateTaskDto dto)
        {
            var task = await _service.AddTaskAsync(dto.title);
            return Ok(task);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateTaskDto dto)
        {
            var result = await _service.UpdateTaskAsync(id, dto.title, dto.IsCompleted);
            if (!result)
            {
                return NotFound("Task not found");
            }
            return Ok("Task marked as completed");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteTaskAsync(id);
            if(!result)
                return NotFound("Task not found");
            return NoContent();
        }

    }
}