using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BB360TestBrief.Infrastructure;
using BB360TestBrief.Infrastructure.Auth;
using BB360TestBrief.Infrastructure.Jwt;
using BB360TestBrief.Infrastructure.Middlewares;
using BB360TestBrief.Infrastructure.Persistence;
using BB360TestBrief.Infrastructure.Swagger;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPersistence(Configuration);
            services.AddApplication();
            services.AddJWT(Configuration);
            services.AddAuth(Configuration);
            services.AddSwaggerService(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("corsPolicy", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });
            services.AddControllers(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add<ValidationFilter>();
            })
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>())
            .ConfigureApiBehaviorOptions(option => { option.SuppressModelStateInvalidFilter = true; });
            // services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("corsPolicy");
            app.UseSwaggerService(Configuration);
            app.UseRouting();
            app.UseCustomExceptionHandler();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseFileServer();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
