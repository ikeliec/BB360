namespace BB360TestBrief.Infrastructure.Jwt
{
   public class JwtSettings
   {
      public string Secret { get; set; }
      public int ExpiryMinutes { get; set; }
      public string Issuer { get; set; }
   }

   public class JsonWebToken
   {
      public string Token { get; set; }
      public long Expires { get; set; }
      public string UserType { get; set; }
      // public string IsRegistrationVerified { get; set; }
      // public string ProfileCode { get; set; }
      public string FullName { get; set; }
   }
}