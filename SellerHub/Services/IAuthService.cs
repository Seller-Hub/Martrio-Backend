using SellerHub.DTOs;
using SellerHub.Models;

namespace SellerHub.Services
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(RegisterDto dto);
        Task<User?> LoginAsync(LoginDto dto);
    }
}
