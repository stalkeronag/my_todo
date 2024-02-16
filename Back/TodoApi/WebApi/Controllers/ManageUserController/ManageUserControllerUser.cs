using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.ManageUserController
{
    [Route("api/")]
    [ApiController]
    public class ManageUserControllerUser : Controller
    {
        [Authorize]
        [HttpPut("ChangePassword")]
        public void ChangePassword()
        {

        }

        [Authorize]
        [HttpPut("ResetPassword")]
        public void ResetPassword(string pass) 
        { 

        }

        [Authorize]
        [HttpPut("ChangeName")]
        public void ChangeName(string name)
        {

        }
    }
}
