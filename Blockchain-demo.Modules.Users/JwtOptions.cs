namespace Blockchain_demo.Modules.Users
{
    public record JwtOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int AudieExpiryMinutesnce { get; set; }
    }
}
