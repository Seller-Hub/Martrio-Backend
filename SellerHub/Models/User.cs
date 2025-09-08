using System.ComponentModel.DataAnnotations;

namespace SellerHub.Models
{
    public class User
    {
        // Primary key
        public int UserId { get; set; }

        // Display name of the user (seller, admin, or customer)
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        // Unique email address used for login
        [Required, MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        // Securely stored password hash (never store plain text passwords)
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        // Role type: seller | admin | customer
        [Required, MaxLength(50)]
        public string Role { get; set; } = "customer";

        // Optional referral code assigned to the user
        [MaxLength(100)]
        public string ReferralCode { get; set; } = string.Empty;

        // Linked account ID (e.g., admin linked to seller, customer linked to admin)
        public int? LinkedTo { get; set; }
    }
}
