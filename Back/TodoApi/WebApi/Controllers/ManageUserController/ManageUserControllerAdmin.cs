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
        public void DeleteUser(int id)
        {

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add_user")]
        public void AddUser(int id)
        {

        }

        [Authorize(Roles = "Admin")]
        [HttpPost("bun_user")]
        public void BunUser(int id)
        {

        }
    }
}
