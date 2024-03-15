using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ManageTodoTasksController
{
    [Route("api/Tasks")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public TasksController(IHttpContextAccessor contextAccessor)
        {
            this._contextAccessor = contextAccessor;
        }

        [Authorize]
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            
            return Ok("hello");
        }

        [HttpGet("GetAllDoneTasks")]
        public async Task<IActionResult> GetAllDoneTasks()
        {
            throw new NotImplementedException();
        }


        [HttpGet("GetAllNotDoneTasks")]
        public async Task<IActionResult> GetAllNotDoneTasks()
        {
            throw new NotImplementedException();
        }

    }
}
