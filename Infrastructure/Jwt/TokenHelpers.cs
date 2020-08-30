using Microsoft.Extensions.DependencyInjection;

namespace BB360TestBrief.Infrastructure.Jwt
{
   public class TokenHelpers
   {
   }
   public class AuthorizationPolicyCodes
   {
      public const string CandidatePolicyCode = "CandidatePolicyCode";
      public const string StaffPolicyCode = "StaffPolicyCode";
   }


   public static class AuthorizationExtensions
   {
      public static IServiceCollection AddZimvestPolicies(this IServiceCollection services)
      {

         services.AddAuthorization(options =>
         {
            options.AddPolicy("StaffProfileOnly", policy => policy.RequireClaim("PolicyCode", AuthorizationPolicyCodes.StaffPolicyCode));
         });


         return services;
      }
   }
}