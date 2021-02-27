namespace Core.Utilities.Security.JWT
{
    public class TokenOptions // helper class oldugu icin cogul
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
