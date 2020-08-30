using Microsoft.AspNetCore.Authorization;

namespace BB360TestBrief.Infrastructure.Auth.Models
{
   public class PermissionRequirement : IAuthorizationRequirement
   {
      public string Permission { get; private set; }
      public PermissionRequirement(string permission)
      {
         Permission = permission;
      }
   }
}