using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SellerHub.DTOs;
using SellerHub.Models;
using SellerHub.Services;
using System.Security.Claims;

namespace SellerHub.Auth.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    // ===========================
    // REGISTER
    // ===========================
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        // Call service to create user
        var user = await _authService.RegisterAsync(dto);

        if (user is null)
            return BadRequest(new { message = "User already exists" });

        // Return safe user info, password never returned
        return Ok(new
        {
            message = "Registered successfully",
            userId = user.UserId,
            name = user.Name,
            email = user.Email,
            role = user.Role,
            referralCode = user.ReferralCode,
            linkedTo = user.LinkedTo
        });
    }

    // ===========================
    // LOGIN
    // ===========================
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var user = await _authService.LoginAsync(dto);

        if (user is null)
            return Unauthorized(new { message = "Invalid credentials" });

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role)
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

        return Ok(new
        {
            message = "Logged in successfully",
            userId = user.UserId,
            name = user.Name,
            email = user.Email,
            role = user.Role,
            referralCode = user.ReferralCode,
            linkedTo = user.LinkedTo
        });
    }

    // ===========================
    // LOGOUT
    // ===========================
    [Authorize]
    [HttpPost("logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Ok(new { message = "Logged out successfully" });
    }

    // ===========================
    // GET CURRENT USER
    // ===========================
    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        return Ok(new
        {
            message = "User info retrieved successfully",
            userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value,
            email = User.FindFirst(ClaimTypes.Email)?.Value,
            role = User.FindFirst(ClaimTypes.Role)?.Value
        });
    }
}
