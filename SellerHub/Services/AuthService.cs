using Microsoft.EntityFrameworkCore;
using SellerHub.Data;
using SellerHub.DTOs;
using SellerHub.Models;

namespace SellerHub.Services
{
    public class AuthService(AppDbContext db) : IAuthService
    {
        public async Task<User?> RegisterCustomerAsync(RegisterCustomerDto dto)
        {
            if (await db.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                Role = "customer",
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Region = dto.Region,
                TermsAccepted = dto.TermsAccepted,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> RegisterSellerStep1Async(RegisterSellerStep1Dto dto)
        {
            if (await db.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                Role = "seller",
                Email = dto.Email,
                Region = dto.Region,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> RegisterSellerStep2Async(int userId, RegisterSellerStep2Dto dto)
        {
            var user = await db.Users.FindAsync(userId);
            if (user == null || user.Role != "seller") return null;

            user.CompanyName = dto.CompanyName;
            user.ProductCategory = dto.ProductCategory;
            user.WebsiteUrl = dto.WebsiteUrl;
            user.TaxId = dto.TaxId;
            user.TermsAccepted = dto.TermsAccepted;

            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> RegisterAdminStep1Async(RegisterAdminStep1Dto dto)
        {
            if (await db.Users.AnyAsync(u => u.Email == dto.Email))
                return null;

            var user = new User
            {
                Role = "admin",
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            db.Users.Add(user);
            await db.SaveChangesAsync();
            return user;
        }

        public async Task<User?> RegisterAdminStep2Async(int userId, RegisterAdminStep2Dto dto)
        {
            var user = await db.Users.FindAsync(userId);
            if (user == null || user.Role != "admin") return null;

            user.ContentDescription = dto.ContentDescription;
            user.Region = dto.Region;
            user.WebsiteUrl = dto.WebsiteUrl;
            user.HowDidYouHearAboutUs = dto.HowDidYouHearAboutUs;
            user.TermsAccepted = dto.TermsAccepted;

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
