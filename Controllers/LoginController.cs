using KiproshBirthdayCelebration.BuisnessLogic.Abstract;
using KiproshBirthdayCelebration.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticateService AuthService;
        public LoginController(IAuthenticateService authService)
        {
            AuthService = authService;
        }

        [AllowAnonymous]
        [HttpPost("token")]
        public IActionResult Token([FromBody] AuthenticateRequest request)
        {
            var user = AuthService.AuthenticateUser(request.Username, request.Password);
            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenString = AuthService.GenerateJSONWebToken(user);
            return Ok(new { token = tokenString });
        }
    }
}