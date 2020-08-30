using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Jwt;
using FluentValidation;
using MediatR;

namespace BB360TestBrief.Core.Commands.Login
{
   public class LoginCommand : IRequest<BaseResponse<JsonWebToken>>
   {
      public string EmailAddress { get; set; }
      public string Password { get; set; }
   }

   public class LoginCommandValidator : AbstractValidator<LoginCommand>
   {
      public LoginCommandValidator()
      {
         RuleFor(x => x.EmailAddress).NotEmpty().NotNull();
         RuleFor(x => x.Password).NotEmpty().NotNull();
      }
   }
}