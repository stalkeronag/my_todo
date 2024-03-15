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

        public UserAuthController(IUserService userService, ITokenService tokenService, IUserRoleService roleService, IMapper mapper)
        {
            this.userService = userService;
            this.tokenService = tokenService;
            this.roleService = roleService;
            this.mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            User currentUser = await userService.GetUserByEmail(loginDto.Email);
            var role = roleService.GetRolesByUserId(currentUser.Id).First();
            string accessToken = tokenService.GenerateAccessToken(currentUser, role);
            return Ok(accessToken);
        }


        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
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
    }
}
