using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers.ManageTodoTasksController
{
    [Route("api/Tasks")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        private readonly ITokenManagerService tokenManagerService;
        public TasksController(IHttpContextAccessor contextAccessor, ITokenManagerService tokenManagerService)
        {
            this._contextAccessor = contextAccessor;
            this.tokenManagerService = tokenManagerService;
        }

        [Authorize]
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            return Ok(_contextAccessor.HttpContext.Request.Cookies["refreshToken"]);
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
