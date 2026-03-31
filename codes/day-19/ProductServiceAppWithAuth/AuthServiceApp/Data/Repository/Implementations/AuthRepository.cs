using AuthServiceApp.Data.Context;
using AuthServiceApp.Data.Entities;
using AuthServiceApp.Data.Repository.Abstractions;
using AuthServiceApp.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AuthServiceApp.Data.Repository.Implementations
{
    public class AuthRepository(AuthDbContext context, IMapper mapper) : IAuthRepository
    {
        private readonly AuthDbContext context = context;
        private readonly IMapper mapper = mapper;

        public async Task<bool> AuthenticateAsync(LoginDTO loginDTO)
        {
            try
            {
                return await context.Users.AnyAsync(u => u.Email == loginDTO.Email && u.Password == loginDTO.Password);
            }
            catch
            {

                throw;
            }
        }

        public async Task<UserDTO> RegisterAsync(UserDTO userDTO)
        {
            try
            {
                bool exists = await context.Users.AnyAsync(u => u.Email == userDTO.Email);
                if (!exists)
                {
                    UserEntity user = mapper.Map<UserEntity>(userDTO);
                    _ = await context.Users.AddAsync(user);
                    var result = await context.SaveChangesAsync();
                    return result > 0 ? userDTO : throw new Exception("could not add");
                }
                else
                    throw new Exception($"user with email: {userDTO.Email} already exists");
            }
            catch
            {
                throw;
            }
        }
    }
}
