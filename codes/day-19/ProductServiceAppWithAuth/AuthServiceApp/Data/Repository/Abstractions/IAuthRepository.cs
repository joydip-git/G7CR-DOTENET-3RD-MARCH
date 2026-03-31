using AuthServiceApp.DTOs;

namespace AuthServiceApp.Data.Repository.Abstractions
{
    public interface IAuthRepository
    {
        Task<UserDTO> RegisterAsync(UserDTO userDTO);
        Task<bool> AuthenticateAsync(LoginDTO loginDTO);
    }
}
