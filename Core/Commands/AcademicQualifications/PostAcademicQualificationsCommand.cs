using System.Collections.Generic;
using System.Text.Json.Serialization;
using BB360TestBrief.Data.Models;
using FluentValidation;
using MediatR;

namespace BB360TestBrief.Core.Commands.AcademicQualifications
{
   public class PostAcademicQualificationsCommand : IRequest<BaseResponse<List<AcademicQualificatonDTO>>>
   {
      [JsonIgnore]
      public long UserId { get; set; }
		public List<AcademicQualification> Qualifications { get; set; }
   }

   public class AcademicQualification
   {
      public string Academy { get; set; }
      public string Certification { get; set; }
      public string StartYear { get; set; }
      public string EndYear { get; set; }
   }

	public class PostAcademicQualificationsCommandValidator : AbstractValidator<PostAcademicQualificationsCommand>
   {
      public PostAcademicQualificationsCommandValidator()
      {
         RuleForEach(x => x.Qualifications).NotEmpty().NotNull();
      }
   }
}