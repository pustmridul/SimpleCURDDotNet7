namespace SimpleCURDDotNet7.Data
{
    public class UserInfo : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
