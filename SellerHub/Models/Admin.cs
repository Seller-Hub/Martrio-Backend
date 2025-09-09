using System.ComponentModel.DataAnnotations;

namespace SellerHub.Models
{
    public class Admin : User
    {
        public string AdminId => GetUniqueUserIdRepresentation();

        [MaxLength(500)]
        public string ContentDescription { get; set; } = string.Empty;

        [MaxLength(200)]
        public string HowDidYouHearAboutUs { get; set; } = string.Empty;

        public bool TermsAccepted { get; set; } = false;

        public Admin(string firstName, string lastName, string email, string password)
            : base(firstName, lastName, email, password, UserRole.Admin) { }

    }

}