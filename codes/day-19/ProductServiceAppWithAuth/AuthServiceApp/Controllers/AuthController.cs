using AuthServiceApp.Data.Repository.Abstractions;
using AuthServiceApp.DTOs;
using AuthServiceApp.TokenManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthServiceApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(ITokenManager tokenManager, IAuthRepository authRepository) : ControllerBase
    {
        private readonly ITokenManager tokenManager = tokenManager;
        private readonly IAuthRepository authRepository = authRepository;

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<UserDTO>> RegisterAnUserAsync([FromBody] UserDTO user)
        {
            try
            {
                var value = await authRepository.RegisterAsync(user);
                return CreatedAtAction(nameof(RegisterAnUserAsync), value);
            }
            catch (Exception e)
            {
                return this.Problem(detail: e.Message, statusCode: 500);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> LoginUserAsync([FromBody] LoginDTO loginUser)
        {
            try
            {
                var exists = await authRepository.AuthenticateAsync(loginUser);
                if (exists)
                {
                    string token = tokenManager.GenerateToken(loginUser);
                    return Ok(token);
                }
                else
                {
                    return Problem(detail: "invalid user", statusCode: 500);
                }
            }
            catch (Exception e)
            {
                return this.Problem(detail: e.Message, statusCode: 500);
            }
        }
    }
}
