using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ManageUserController
{
    [Route("api/")]
    [ApiController]
    public class ManageUserControllerAdmin : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpDelete("delete_user")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add_user")]
        public async Task<IActionResult> AddUser(int id)
        {
            return Ok(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("bun_user")]
        public async Task<IActionResult> BunUser(int id)
        {
            return Ok(id);
        }
    }
}
