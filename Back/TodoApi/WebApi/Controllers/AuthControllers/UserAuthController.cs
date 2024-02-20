using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers.AuthControllers
{
    [Route("api/")]
    [ApiController]
    public class UserAuthController : Controller
    {
        private IUserService userService;

        private IAuthService authService;

        public UserAuthController(IUserService userService, IAuthService authService)
        {
            this.userService = userService;
            this.authService = authService;
        }

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
