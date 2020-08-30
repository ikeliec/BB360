using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BB360TestBrief.Infrastructure.Jwt
{
   public static class Extension
   {
      public static IServiceCollection AddJWT(this IServiceCollection services, IConfiguration configuration)
      {

         var authenticationProviderKey = "JwtBearer";
         var jwtSettings = new JwtSettings();
         configuration.Bind(nameof(JwtSettings), jwtSettings);
         services.AddSingleton(jwtSettings);
         services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
         services.AddSingleton<IJwtHandler, JwtHandler>();

         services.AddAuthentication(options =>
             {
                options.DefaultAuthenticateScheme = authenticationProviderKey;
                options.DefaultScheme = authenticationProviderKey;
                options.DefaultChallengeScheme = authenticationProviderKey;
                options.DefaultForbidScheme = authenticationProviderKey;
             })
             .AddJwtBearer(authenticationProviderKey, options =>
             {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                   ValidateIssuerSigningKey = true,
                   ValidateAudience = false,
                   ValidateIssuer = false,
                   RequireExpirationTime = true,
                   ValidateLifetime = true,
                   ValidIssuer = jwtSettings.Issuer,
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                };
             });

         return services;
      }
   }
}