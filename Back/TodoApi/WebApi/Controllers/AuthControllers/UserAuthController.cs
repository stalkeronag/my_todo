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

        private IAuthService authService;

        private ITokenService tokenService;

        public UserAuthController(IUserService userService, IAuthService authService, ITokenService tokenService)
        {
            this.userService = userService;
            this.authService = authService;
            this.tokenService = tokenService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            User currentUser = await userService.GetUserByEmail(loginDto.Email);

            string accessToken = await tokenService.GenerateAccessToken(currentUser, null);
            return Ok(accessToken);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            User currentUser = await userService.GetUserByEmail(registerDto.Email);
            await userService.AddUser(currentUser);
            await userService.AddRoleInUserById(currentUser.Id);
            return Ok(registerDto);
        }
    }
}
