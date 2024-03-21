using AutoMapper;
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

        private IMapper mapper;

        private ITokenService tokenService;

        private IUserRoleService roleService;

        private IAuthService authService;

        public UserAuthController(IUserService userService, ITokenService tokenService, IUserRoleService roleService, IMapper mapper, IAuthService authService)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.roleService = roleService;
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            User currentUser = await userService.GetUserByEmail(loginDto.Email);
            var role = roleService.GetRolesByUserId(currentUser.Id).First();
            string accessToken = tokenService.GenerateAccessToken(currentUser, role);
            string refreshToken = tokenService.GenerateRefreshToken(currentUser);
            return Ok(new PairTokens()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            });
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerUser = await userService.GetUserByEmail(registerDto.Email);

            if (registerUser != null)
            {
                return BadRequest("such user exist");
            } else
            {
                var user = mapper.Map<User>(registerDto);
                await userService.AddUser(user, registerDto.Password);
                return Ok();
            }


        }


        [HttpGet]
        public async Task<IActionResult> RefreshToken()
        {
            User currentUser = await authService.GetCurrentUser();
            return Ok();
        }
    }
}
