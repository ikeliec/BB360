using System.Collections.Generic;
using System.Security.Claims;

namespace BB360TestBrief.Infrastructure.Jwt
{
   public interface IJwtHandler
   {
      JsonWebToken Create(long userId, string email, string fullName, int userType, List<Claim> roleClaims, string policyCode, bool isRegistrationVerified);
   }
}