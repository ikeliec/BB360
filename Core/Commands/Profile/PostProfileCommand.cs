using System;
using System.Text.Json.Serialization;
using BB360TestBrief.Data.Models;
using FluentValidation;
using MediatR;

namespace BB360TestBrief.Core.Commands.Profile
{
   public class PostProfileCommand : IRequest<BaseResponse<ProfileDTO>>
   {
		[JsonIgnore]
      public long UserId { get; set; }
      public string Gender { get; set; }
      public DateTime DateOfBirth { get; set; }
      public string Address { get; set; }
      public string Nationality { get; set; }
      public string StateOfOrigin { get; set; }
      public string LGAOfOrigin { get; set; }
      public string TownOfOrigin { get; set; }
   }

   public class PostProfileCommandValidator : AbstractValidator<PostProfileCommand>
   {
      public PostProfileCommandValidator()
      {
         RuleFor(x => x.Gender).NotEmpty().NotNull();
         RuleFor(x => x.DateOfBirth).NotEmpty().NotNull();
         RuleFor(x => x.Address).NotEmpty().NotNull();
         RuleFor(x => x.Nationality).NotEmpty().NotNull();
         RuleFor(x => x.StateOfOrigin).NotEmpty().NotNull();
         RuleFor(x => x.LGAOfOrigin).NotEmpty().NotNull();
         RuleFor(x => x.TownOfOrigin).NotEmpty().NotNull();
      }
   }
}