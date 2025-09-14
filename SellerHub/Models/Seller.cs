using System.ComponentModel.DataAnnotations;

namespace SellerHub.Models
{
    public class Seller : User
    {

        public string SellerId => GetUniqueUserIdRepresentation();

        [MaxLength(200)]
        public string CompanyName { get; set; } = string.Empty;

        [MaxLength(100)]
        public string ProductCategory { get; set; } = string.Empty;

        [MaxLength(200)]
        public string WebsiteUrl { get; set; } = string.Empty;

        [MaxLength(50)]
        public string TaxId { get; set; } = string.Empty;


        public Seller(string firstName, string lastName, string email, string password, bool termsAccepted)
            : base(firstName, lastName, email, password, UserRole.Seller, termsAccepted) { }
    }
}