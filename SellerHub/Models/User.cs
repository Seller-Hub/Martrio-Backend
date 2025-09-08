using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;

namespace SellerHub.Models {
    // Role type: Seller | Admin | Customer
    public enum UserRole {
        Seller = 0,
        Admin = 1,
        Customer = 2
    }

    public class User {
        // ----- Static Fields -----
        private static int _counter = 0; // for assigning UserIds
        private static readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        // ----- Properties -----
        // Unique numeric ID (auto-assigned)
        protected int UserId { get; }

        // Display name of the user
        [Required, MaxLength(100)]
        public string Name { get; private set; } = string.Empty;

        // Email used for login
        [Required, MaxLength(100), EmailAddress]
        public string Email { get; private set; } = string.Empty;

        // Secure password hash (never store plain text)
        [Required]
        private string PasswordHash { get; set; } = string.Empty;

        // User role
        [Required]
        public UserRole Role { get; private set; } = UserRole.Customer;

        // Optional referral code
        [MaxLength(100)]
        public string ReferralCode { get; set; } = string.Empty;

        // Linked account ID (nullable)
        public int? LinkedTo { get; set; }

        // ----- Constructor -----
        protected User(string name, string email, string password, UserRole role) {
            UserId = ++_counter;
            Name = name;
            Role = role;

            if (!IsValidEmail(email))
                throw new ArgumentException("Invalid email address.", nameof(email));
            Email = email;

            SetPassword(password);
        }

        // ----- Password Methods -----
        public void SetPassword(string password) {
            PasswordHash = _passwordHasher.HashPassword(this, password);
        }

        public bool VerifyPassword(string password) {
            var result = _passwordHasher.VerifyHashedPassword(this, PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        // ----- Email Validation -----
        private bool IsValidEmail(string email) {
            try {
                var addr = new MailAddress(email);
                return addr.Address == email;
            } catch {
                return false;
            }
        }

        // ----- Unique Representation -----
        public string GetUniqueUserIdRepresentation() {
            return Role switch {
                UserRole.Seller => $"SLL-{UserId:D4}",
                UserRole.Admin => $"ADM-{UserId:D4}",
                UserRole.Customer => $"CST-{UserId:D4}",
                _ => UserId.ToString()
            };
        }
    }
}