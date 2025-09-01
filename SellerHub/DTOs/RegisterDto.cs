namespace SellerHub.DTOs
{
    public record RegisterDto(
         string Name,
         string Email,
         string Password,
         string Role = "customer",
         string? ReferralCode = null,
         int? LinkedTo = null
     );
}
