using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace BB360TestBrief.Infrastructure.Swagger
{
    public class SwaggerOptions
    {
        public string Title { get; set; }
        public string Version { get; set; }
    }

    public static class Extensions
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services, IConfiguration configuration)
        {

            SwaggerOptions options = new SwaggerOptions();
            options.Title = "REMOTE TEST (TECHNICAL)";
            options.Version = "v1";


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = $"{options.Title} API", Version = $"{options.Version}" });
                c.IncludeXmlComments(Path.ChangeExtension(Assembly.GetEntryAssembly().Location, "xml"));
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.CustomSchemaIds(x => x.FullName);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });

            });
            return services;
        }


        public static IApplicationBuilder UseSwaggerService(this IApplicationBuilder builder, IConfiguration configuration)
        {
            builder.UseSwagger();
            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", $"{configuration["Swagger:Title"]} API v1");
            });

            return builder;
        }
    }
}