using System.Collections.Generic;
using System.Text.Json.Serialization;
using BB360TestBrief.Data.Models;
using FluentValidation;
using MediatR;

namespace BB360TestBrief.Core.Commands.ProfessionalExperience
{
   public class PostProfessionalExperienceCommand : IRequest<BaseResponse<List<ProfessionalExperienceDTO>>>
   {
      [JsonIgnore]
      public long UserId { get; set; }
      public List<ProfessionalExperience> Experience { get; set; }
   }

   public class ProfessionalExperience
   {
      public string Organization { get; set; }
      public string JobRole { get; set; }
      public string Description { get; set; }
      public string StartYear { get; set; }
      public string EndYear { get; set; }
   }

   public class PostProfessionalExperienceCommandValidator : AbstractValidator<PostProfessionalExperienceCommand>
   {
      public PostProfessionalExperienceCommandValidator()
      {
         RuleForEach(x => x.Experience).NotEmpty().NotNull();
      }
   }
}