using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief.Core.Queries.Documents
{
   public class GetDocumentTemplateQuery : IRequest<BaseResponse<List<DocumentTemplateDTO>>>
   {
      public string BaseUrl { get; set; }
   }

   public class GetDocumentTemplateQueryHandler : IRequestHandler<GetDocumentTemplateQuery, BaseResponse<List<DocumentTemplateDTO>>>
   {
      private readonly BB360DBContext _context;
      private readonly ILogger<GetDocumentTemplateQueryHandler> _logger;

      public GetDocumentTemplateQueryHandler(
         BB360DBContext context,
         ILogger<GetDocumentTemplateQueryHandler> logger
      )
      {
         _context = context;
         _logger = logger;
      }

      public Task<BaseResponse<List<DocumentTemplateDTO>>> Handle(GetDocumentTemplateQuery request, CancellationToken cancellationToken)
      {
         var templates = _context.DocumentTemplates.OrderBy(t => t.Name).ToList();

         var response = new List<DocumentTemplateDTO>();
         templates.ForEach(template =>
         {
            response.Add(new DocumentTemplateDTO
            {
               Id = template.Id,
               DocumentLink = !string.IsNullOrWhiteSpace(template.FilePath) ? $"{request.BaseUrl}/{template.FilePath}" : null,
               DocumentTemplateName = template.Name,
            });
         });

         return Task.FromResult(new BaseResponse<List<DocumentTemplateDTO>>(true, "Document templates retrieved successfully", response));
      }
   }
}