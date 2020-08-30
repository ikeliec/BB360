using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;

namespace BB360TestBrief.Infrastructure.Auth
{
   public static class PrincipalUtils
   {
      public static long GetProfileId(this IIdentity identity)
      {
         return long.Parse(GetClaimValue(identity, ClaimTypes.NameIdentifier));
      }


      public static string GetEmail(this IIdentity identity)
      {
         return GetClaimValue(identity, "email");
      }


      private static string GetClaimValue(this IEnumerable<Claim> claims, string claimType)
      {
         var claimsList = new List<Claim>(claims);
         var claim = claimsList.Find(c => c.Type == claimType);
         return claim != null ? claim.Value : null;
      }

      private static string GetClaimValue(IIdentity identity, string claimType)
      {
         var claimIdentity = (ClaimsIdentity)identity;
         return claimIdentity.Claims.GetClaimValue(claimType);
      }
   }
}