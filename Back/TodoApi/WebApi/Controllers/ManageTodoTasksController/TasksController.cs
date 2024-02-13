using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ManageTodoTasksController
{
    [Route("api/Tasks")]
    [ApiController]
    public class TasksController : Controller
    {
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            throw new NotImplementedException();
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
