using System.Text.Json.Serialization;
using BB360TestBrief.Data.Models;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BB360TestBrief.Core.Commands.Documents
{
   public class UploadDocumentCommand : IRequest<BaseResponse<string>>
   {
      internal long UserId { get; set; }
      public long TemplateId { get; set; }
      // public string DocumentName { get; set; }
      public IFormFile DocumentFile { get; set; }
   }

   public class UploadDocumentCommandValidator : AbstractValidator<UploadDocumentCommand>
   {
      public UploadDocumentCommandValidator()
      {
         RuleFor(x => x.TemplateId).NotEmpty().NotNull();
         // RuleFor(x => x.DocumentName).NotEmpty().NotNull();
         RuleFor(x => x.DocumentFile).NotEmpty().NotNull();
      }
   }
}