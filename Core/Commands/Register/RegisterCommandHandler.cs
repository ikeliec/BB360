using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Enums;
using BB360TestBrief.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BB360TestBrief.Core.Commands.Register
{
   public class RegisterCommandHandler : IRequestHandler<RegisterCommand, BaseResponse>
   {
      private readonly UserManager<BB360User> _userManager;
      private readonly RoleManager<ApplicationRole> _roleManager;
      private readonly BB360DBContext _context;
      private readonly ILogger<RegisterCommandHandler> _logger;

      public RegisterCommandHandler(
         UserManager<BB360User> userManager,
         RoleManager<ApplicationRole> roleManager,
         BB360DBContext context,
         ILogger<RegisterCommandHandler> logger
      )
      {
         _userManager = userManager;
         _roleManager = roleManager;
         _context = context;
         _logger = logger;
      }

      public async Task<BaseResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
      {
         var email = request.EmailAddress.Trim().ToLowerInvariant();
         var existingUser = _userManager.FindByEmailAsync(email).Result;

         if (existingUser != null)
         {
            return new BaseResponse(false, "User with email already exists");
         }

         var newUser = new BB360User
         {
            Email = email,
            UserName = email,
            EmailConfirmed = false,
            PhoneNumber = request.PhoneNumber,
            FirstName = request.FirstName,
            LastName = request.LastName,
            TimeCreated = DateTime.Now,
            TimeUpdated = DateTime.Now,
            UserType = (int)UserTypeEnum.Candidate
         };

         // string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
         // string password = new string(Enumerable.Repeat(chars, 10).Select(s => s[new Random().Next(s.Length)]).ToArray());

         var registerAttempt = _userManager.CreateAsync(newUser, request.Password).Result;
         if (!registerAttempt.Succeeded)
         {
            var errors = registerAttempt.Errors.Select(x => x.Description).ToList();
            return new BaseResponse(false, "There were errors found in your submission. Please review and retry");
         }

         var application = new JobApplication
         {
            Comment = request.Comment,
            JobRole = request.JobRole,
            LinkedInProfileLink = request.LinkedInProfileLink,
            NewsSource = request.NewsSource,
            PortfolioLink = request.PortfolioLink,
            PrimarySkills = JsonConvert.SerializeObject(request.PrimarySkills),
            ProblemSolverOpinion = request.ProblemSolverOpinion,
            ReferralName = request.ReferralName,
            RiskOutcome = request.RiskOutcome,
            RiskSituation = request.RiskSituation,
            TimeCreated = DateTime.Now,
            TimeUpdated = DateTime.Now,
            UserId = newUser.Id,
            IsSuccessful = false
         };
         _context.Add(application);
         _context.SaveChanges();

         // _ =_mediator.Send(new SendEmailConfirmationCommand { User = newUser });

         return await Task.FromResult(new BaseResponse(true, "Job application submitted successfully. A new account has been created for you. Login credentials has been sent to your email address"));
      }
   }
}