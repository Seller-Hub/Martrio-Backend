using Microsoft.EntityFrameworkCore;
using SellerHub.Data;
using SellerHub.DTOs;
using SellerHub.Models;

namespace SellerHub.Services
{
    public class AuthService(AppDbContext db) : IAuthService
    {
        public async Task<User?> RegisterAsync(RegisterDto dto)
        {
            if (await db.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> LoginAsync(LoginDto dto)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
