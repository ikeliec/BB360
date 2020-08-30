using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Jwt;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief.Core.Commands.Login
{
   public class LoginCommandHandler : IRequestHandler<LoginCommand, BaseResponse<JsonWebToken>>
   {
      private readonly UserManager<BB360User> _userManager;
      private readonly RoleManager<ApplicationRole> _roleManager;
      private readonly SignInManager<BB360User> _signInManager;
      private readonly IJwtHandler _jwtHandler;
      private readonly ILogger<LoginCommandHandler> _logger;

      public LoginCommandHandler(
         UserManager<BB360User> userManager,
         RoleManager<ApplicationRole> roleManager,
         SignInManager<BB360User> signInManager,
         IJwtHandler jwtHandler,
         ILogger<LoginCommandHandler> logger
      )
      {
         _userManager = userManager;
         _signInManager = signInManager;
         _roleManager = roleManager;
         _jwtHandler = jwtHandler;
         _logger = logger;
      }

      public async Task<BaseResponse<JsonWebToken>> Handle(LoginCommand request, CancellationToken cancellationToken)
      {
         var email = request.EmailAddress.Trim().ToLowerInvariant();

         var user = await _userManager.FindByEmailAsync(email);
         if (user == null)
         {
            return new BaseResponse<JsonWebToken>(false, "Email address is incorrect");
         }

         // if (!await _userManager.IsEmailConfirmedAsync(user))
         // {
         //    return new BaseResponse<JsonWebToken>(false, "User has not confirmed email. Please confirm email.");
         // }

         var result = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
         if (!result.Succeeded)
         {
            // if (result.IsLockedOut)
            // {
            //    return new BaseResponse<JsonWebToken>(false, "Your profile has been locked. Please initiate a password reset to unlock your profile.");
            // }
            // else
            // {
            //    int maxAttempts = _userManager.Options.Lockout.MaxFailedAccessAttempts;
            //    int failedAttempts = await _userManager.GetAccessFailedCountAsync(user);
            //    return new BaseResponse<JsonWebToken>(false, $"Invalid credentials supplied. You have {maxAttempts - failedAttempts} attempts left.");
            // }

            return new BaseResponse<JsonWebToken>(false, $"Invalid credentials supplied. Email or password is incorrect");
         }

         List<Claim> claims = new List<Claim>();
         //get role claims here
         var roleNames = await _userManager.GetRolesAsync(user);
         var roles = _roleManager.Roles.Where(x => roleNames.Contains(x.Name)).ToList();

         foreach (ApplicationRole role in roles)
         {
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            claims.AddRange(roleClaims);
         }

         // await _userManager.ResetAccessFailedCountAsync(user);
         //generate token
         var tokenResult = _jwtHandler.Create(
            user.Id,
            user.Email,
            $"{user.FirstName} {user.LastName}",
            user.UserType,
            claims, GetAuthorizationCode(user.UserType),
          	true
         );

         return new BaseResponse<JsonWebToken>(true, "Login successful", tokenResult);
      }

      private string GetAuthorizationCode(int userType)
      {
         switch (userType)
         {
            case 1: return AuthorizationPolicyCodes.CandidatePolicyCode;
            case 2: return AuthorizationPolicyCodes.StaffPolicyCode;
         }
         return "";
      }
   }
}