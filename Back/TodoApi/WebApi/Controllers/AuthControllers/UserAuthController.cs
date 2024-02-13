using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers.AuthControllers
{
    [Route("api/")]
    [ApiController]
    public class UserAuthController : Controller
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            return Ok(loginDto);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            return Ok(registerDto);
        }
    }
}
