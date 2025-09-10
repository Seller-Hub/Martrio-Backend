using Microsoft.EntityFrameworkCore;
using SellerHub.Data;
using SellerHub.DTOs;
using SellerHub.Models;
using System;

namespace SellerHub.Services
{
    public class AuthService(AppDbContext db) : IAuthService
    {
        // ===========================
        // REGISTER
        // ===========================
        public async Task<User?> RegisterAsync(RegisterDto dto)
        {
            // Check if email already exists
            if (await db.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            // Create new user
            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = user.SetPassword(dto.Password), // BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = dto.Role,
                // ReferralCode = dto.ReferralCode ?? string.Empty,
                // LinkedTo = dto.LinkedTo
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        // ===========================
        // LOGIN
        // ===========================
        public async Task<User?> LoginAsync(LoginDto dto)
        {
            var user = await db.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user is null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null;

            return user;
        }
    }
}
