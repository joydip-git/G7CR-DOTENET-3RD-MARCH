using AuthServiceApp.DTOs;
using AuthServiceApp.OptionsSettings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthServiceApp.TokenManager
{
    //public class JwtTokenManager(IConfiguration configuration, ILogger<JwtTokenManager> logger) : ITokenManager
    public class JwtTokenManager(IOptions<Jwt> options, ILogger<JwtTokenManager> logger) : ITokenManager
    {
        //private readonly IConfiguration configuration = configuration;
        private readonly IOptions<Jwt> options = options;
        private readonly ILogger<JwtTokenManager> logger = logger;

        public string GenerateToken(LoginDTO login)
        {
            string key = options.Value.SecretKey ?? "apiy1Wx2Pe5oFkrs68y0iTyUTGFNxwvdY8eekFfYXCm4lm4iwgF2FoogxAjeF3PTH4FNEMw5YXwTHetcJCXTOQuWiiiIUR30wPBJR0L0oC5wBzhZ35LpmlWTPcIyURXl";
            SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials signingCredentials = new SigningCredentials(key: securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
                [
                    new Claim(type: JwtRegisteredClaimNames.Sub, value: login.Email),
                    new Claim(type:JwtRegisteredClaimNames.Name, value:login.Role)
                ];

            JwtSecurityToken accesToken = new JwtSecurityToken(
                issuer: options.Value.Issuer ?? "http://localhost:5151",
                audience: options.Value.Audience ?? "http://localhost:5151",
                expires: DateTime.Now.AddMinutes(10),
                claims: claims,
                signingCredentials: signingCredentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(accesToken);
            logger.LogInformation($"token created by token manager {token}");
            return token;
        }
    }
}
