public class Seller : User {

    public string SellerID => GetUniqueUserIdRepresentation();

    public Seller(string name, string email, string password)
        : base(name, email, password, UserRole.Seller) { }
}