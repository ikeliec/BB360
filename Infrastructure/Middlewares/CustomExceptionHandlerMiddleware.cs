using System;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using BB360TestBrief.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BB360TestBrief.Infrastructure.Middlewares
{
   public class CustomExceptionHandlerMiddleware
   {
      private readonly RequestDelegate _next;
      private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

      public CustomExceptionHandlerMiddleware(RequestDelegate next, ILogger<CustomExceptionHandlerMiddleware> logger)
      {
         _next = next;
         _logger = logger;
      }

      public string TraceId
      {
         get
         {
            return Activity.Current?.Id;
         }
      }


      public async Task InvokeAsync(HttpContext context)
      {
         try
         {
            await _next(context);
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex.Message);
            _logger?.LogCritical(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
         }
      }

      private async Task HandleExceptionAsync(HttpContext context, Exception exception)
      {
         var code = HttpStatusCode.InternalServerError;
         string result = String.Empty;

         var innermostException = exception.GetBaseException();


         if (string.IsNullOrEmpty(result))
         {
            result = JsonConvert.SerializeObject(new ErrorResponse { Message = innermostException.Message });
         }

         context.Response.ContentType = "application/json";
         context.Response.StatusCode = (int)code;
         if (code == HttpStatusCode.BadRequest)
         {
            _logger?.LogError(result);
         }
         else if (code == HttpStatusCode.InternalServerError)
         {
            _logger?.LogCritical($@"result - {result}
                    {Environment.NewLine}
                    traceid - {TraceId}
                    {Environment.NewLine}
                    Stacktrace - {innermostException.StackTrace}");

            _logger?.LogCritical(innermostException, innermostException.Message);
            result = JsonConvert.SerializeObject(new ErrorResponse { TraceId = TraceId, Message = innermostException.Message });

         }

         await context.Response.WriteAsync(result);
      }
   }

   public static class CustomExceptionHandlerMiddlewareExtensions
   {
      public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
      {
         return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
      }
   }
}