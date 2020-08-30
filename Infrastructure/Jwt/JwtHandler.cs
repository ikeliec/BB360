using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BB360TestBrief.Infrastructure.Enums;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BB360TestBrief.Infrastructure.Jwt
{
   public class JwtHandler : IJwtHandler
   {
      private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
      private readonly JwtSettings _options;
      private readonly SecurityKey _issuerSigningKey;
      private readonly SigningCredentials _signingCredentials;
      private readonly JwtHeader _jwtHeader;
      private readonly TokenValidationParameters _tokenValidationParameters;

      public JwtHandler(IOptions<JwtSettings> options)
      {
         _options = options.Value;
         _issuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Secret));
         _signingCredentials = new SigningCredentials(_issuerSigningKey, SecurityAlgorithms.HmacSha256);
         _jwtHeader = new JwtHeader(_signingCredentials);
         _tokenValidationParameters = new TokenValidationParameters
         {
            ValidateIssuerSigningKey = true,
            ValidateAudience = false,
            ValidateIssuer = false,
            RequireExpirationTime = true,
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_options.Secret))
         };
      }

      public JsonWebToken Create(long userId, string email, string fullName, int userType, List<Claim> roleClaims, string profileCode, bool isRegistrationVerified)
      {
         var nowUtc = DateTime.UtcNow;
         var expires = nowUtc.AddMinutes(_options.ExpiryMinutes);
         var centuryBegins = new DateTime(1970, 1, 1).ToUniversalTime();
         var exp = (long)new TimeSpan(expires.Ticks - centuryBegins.Ticks).TotalSeconds;
         var now = (long)new TimeSpan(nowUtc.Ticks - centuryBegins.Ticks).TotalSeconds;

         var payload = new JwtPayload
            {
                {"sub", userId},
                {"iss", _options.Issuer},
                {"iat", now},
                {"exp", exp},
                {"unique_name", email},
                {"PolicyCode", profileCode}
            };

         if (roleClaims != null && roleClaims.Count > 0)
				payload.AddClaims(roleClaims);

         // var claims = new []
         // {
         //     new Claim(ClaimTypes)
         // }

         var jwt = new JwtSecurityToken(_jwtHeader, payload);
         var token = _jwtSecurityTokenHandler.WriteToken(jwt);

         return new JsonWebToken
         {
            Token = token,
            Expires = exp,
            // IsRegistrationVerified = isRegistrationVerified ? "Verified" : "Not Verified",
            // ProfileCode = profileCode,
            FullName = fullName,
            UserType = ((UserTypeEnum)userType).GetDescription()
         };
      }
   }
}