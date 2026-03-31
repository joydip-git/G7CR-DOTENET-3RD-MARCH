using AuthServiceApp.DTOs;

namespace AuthServiceApp.TokenManager
{
    public interface ITokenManager
    {
        string GenerateToken(LoginDTO login);
    }
}
