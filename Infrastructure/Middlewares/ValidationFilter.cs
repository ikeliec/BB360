using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BB360TestBrief.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BB360TestBrief.Infrastructure.Middlewares
{
   public class ValidationFilter : IAsyncActionFilter
   {
      private readonly ILogger<ValidationFilter> _logger;

      public ValidationFilter(ILogger<ValidationFilter> logger)
      {
         _logger = logger;
      }

      public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
      {

         if (!context.ModelState.IsValid)
         {
            if (context.ActionDescriptor.DisplayName.Contains("Login") || context.ActionDescriptor.DisplayName.Contains("InitiatePasswordReset"))
            {
               await next();
            }

            var modelStateErrors = context.ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

            var errorResponse = new ErrorResponse();

            foreach (var error in modelStateErrors)
            {
               foreach (var subError in error.Value)
               {
                  errorResponse.Errors.Add(subError);
               }
            }
            errorResponse.Message = "Validation errors were found. Please review and retry.";
            errorResponse.TraceId = Activity.Current.Id;
            // errorResponse.ValidationErrors = validationErrors;
            context.Result = new BadRequestObjectResult(errorResponse);
            _logger?.LogError($@"Action - {context.ActionDescriptor.DisplayName}
                    {Environment.NewLine}
                    arguements - {JsonConvert.SerializeObject(context.ActionArguments)}
                    {Environment.NewLine}
                    result - {JsonConvert.SerializeObject(errorResponse)}
                    ");

            return;
         }


         await next();
      }

      public override string ToString()
      {
         return base.ToString();
      }
   }
}