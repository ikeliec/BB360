using System.Linq;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Infrastructure.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BB360TestBrief.Infrastructure.Auth
{
   internal class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
   {
      private readonly UserManager<BB360User> _userManager;
      private readonly RoleManager<ApplicationRole> _roleManager;
      public PermissionAuthorizationHandler(UserManager<BB360User> userManager, RoleManager<ApplicationRole> roleManager)
      {
         _userManager = userManager;
         _roleManager = roleManager;
      }
      protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
      {
         if (context.User == null)
            return;

         // Get all the roles the user belongs to and check if any of the roles has the permission required
         // for the authorization to succeed.
         var user = await _userManager.GetUserAsync(context.User);
         if (user == null)
         {
            return;
         }
         var userRoleNames = await _userManager.GetRolesAsync(user);
         var userRoles = _roleManager.Roles.Where(x => userRoleNames.Contains(x.Name)).ToList();

         foreach (var role in userRoles)
         {
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            var permissions = roleClaims
                .Where(x => x.Type == CustomClaimTypes.Permission && x.Value == requirement.Permission)
                .Select(x => x.Value);

            if (permissions.Any())
            {
               context.Succeed(requirement);
               return;
            }
         }
      }
   }
}