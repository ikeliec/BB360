using System.Collections.Generic;
using BB360TestBrief.Data.Models;
using FluentValidation;
using MediatR;

namespace BB360TestBrief.Core.Commands.Register
{
   public class RegisterCommand : IRequest<BaseResponse>
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string EmailAddress { get; set; }
      public string PhoneNumber { get; set; }
      public string JobRole { get; set; }
      public List<string> PrimarySkills { get; set; }
      public string PortfolioLink { get; set; }
      public string LinkedInProfileLink { get; set; }
      public string NewsSource { get; set; }
      public string ReferralName { get; set; }
      public string RiskSituation { get; set; }
      public string RiskOutcome { get; set; }
      public string ProblemSolverOpinion { get; set; }
      public string Comment { get; set; }
      public string Password { get; set; }
   }

   public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().NotNull();
            RuleFor(x => x.LastName).NotEmpty().NotNull();
            RuleFor(x => x.EmailAddress).NotEmpty().NotNull();
            RuleFor(x => x.PhoneNumber).NotEmpty().NotNull();
            RuleFor(x => x.JobRole).NotEmpty().NotNull();
            RuleForEach(x => x.PrimarySkills).NotEmpty().NotNull();
            RuleFor(x => x.PortfolioLink).NotEmpty().NotNull();
            RuleFor(x => x.LinkedInProfileLink).NotEmpty().NotNull();
            RuleFor(x => x.NewsSource).NotEmpty().NotNull();
            RuleFor(x => x.ReferralName).NotEmpty().NotNull();
            RuleFor(x => x.RiskSituation).NotEmpty().NotNull();
            RuleFor(x => x.RiskOutcome).NotEmpty().NotNull();
            RuleFor(x => x.ProblemSolverOpinion).NotEmpty().NotNull();
            RuleFor(x => x.Comment).NotEmpty().NotNull();
        }
    }
}