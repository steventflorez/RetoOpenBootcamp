namespace FacturasApi.Models
{
    public class UserTokens
    {
        public int Id { get; set; }
        public string Token { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public TimeSpan Validity { get; set; }
        public string RedreshToken { get; set; } = null!;
        public Guid GuidId { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
