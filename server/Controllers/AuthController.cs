using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebAPI_project.BLL.Services;
using WebAPI_project.DTOs;
using WebAPI_project.Models.DTO;
using WebAPI_project.Services;

namespace WebAPI_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _userService.AuthenticateAsync(loginDto.Email, loginDto.Password);
            if (user == null)
                return Unauthorized("Invalid email or password");

            var token = _tokenService.CreateToken(user);
            return Ok(new { token });
        }
    }
}
