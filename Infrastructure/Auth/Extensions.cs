using System;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Infrastructure.Auth.Models;
using BB360TestBrief.Infrastructure.Jwt;
using BB360TestBrief.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BB360TestBrief.Infrastructure.Auth
{
   public static class Extensions
   {
      public static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration Configuration)
      {
         services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

         services.AddIdentity<BB360User, ApplicationRole>(options =>
         {
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
            options.Lockout.MaxFailedAccessAttempts = 5;

            options.User.RequireUniqueEmail = true;

            options.Password.RequireDigit = false;
            options.Password.RequiredLength = 8;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;

            // options.SignIn.RequireConfirmedAccount = true;
            // options.SignIn.RequireConfirmedEmail = true;
         })
         .AddRoles<ApplicationRole>()
         .AddEntityFrameworkStores<BB360DBContext>()
         .AddDefaultTokenProviders();


         services.AddAuthorization(options =>
         {
            options.AddPolicy("StaffProfileOnly", policy => policy.RequireClaim("PolicyCode", AuthorizationPolicyCodes.StaffPolicyCode));

            foreach (RolePermission permission in Permissions.AllPermissions)
            {
               options.AddPolicy(permission.Id, builder =>
                  {
                    builder.AddRequirements(new PermissionRequirement(permission.Id));
                 });

            }
         });


         var jwtSettings = new JwtSettings
         {
            Secret = Configuration["JwtSettings:Secret"],
            ExpiryMinutes = int.Parse(Configuration["JwtSettings:ExpiryMinutes"]),
            Issuer = Configuration["JwtSettings:Issuer"]
         };

         services.AddSingleton<JwtSettings>(jwtSettings);


         return services;
      }
   }
}