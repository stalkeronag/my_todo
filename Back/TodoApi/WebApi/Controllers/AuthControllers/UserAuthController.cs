using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;
using WebApi.Models;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers.AuthControllers
{
    [Route("api/")]
    [ApiController]
    public class UserAuthController : Controller
    {
        private IUserService userService;

     
        private ITokenService tokenService;

        public UserAuthController(IUserService userService, ITokenService tokenService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            UserRole role = new UserRole()
            {
                Name = "admin"
            };
            User currentUser = await userService.GetUserByEmail(loginDto.Email);
            string accessToken = await tokenService.GenerateAccessToken(currentUser, role);
            return Ok(accessToken);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            return null;
        }
    }
}
