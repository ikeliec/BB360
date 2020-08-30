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
   public class GetCustomerDocumentsQuery : IRequest<BaseResponse<List<DocumentDTO>>>
   {
      public long UserId { get; set; }
      public string BaseUrl { get; set; }
   }

   public class GetCustomerDocumentsQueryHandler : IRequestHandler<GetCustomerDocumentsQuery, BaseResponse<List<DocumentDTO>>>
   {
      private readonly BB360DBContext _context;
      private readonly ILogger<GetCustomerDocumentsQueryHandler> _logger;

      public GetCustomerDocumentsQueryHandler(
         BB360DBContext context,
         ILogger<GetCustomerDocumentsQueryHandler> logger
      )
      {
         _context = context;
         _logger = logger;
      }

      public Task<BaseResponse<List<DocumentDTO>>> Handle(GetCustomerDocumentsQuery request, CancellationToken cancellationToken)
      {
         var documents = _context.UserDocuments.Where(d => d.UserId == request.UserId).ToList();

         var documentsDTO = new List<DocumentDTO>();
         if (documents.Any())
         {
            documents.ForEach(document => {
               var template = _context.DocumentTemplates.Find(document.DocumentTemplateId);

               documentsDTO.Add(new DocumentDTO{
                  DocumentLink = !string.IsNullOrWhiteSpace(document.FilePath) ? $"{request.BaseUrl}/{document.FilePath}" : null,
                  DocumentName = document.Name,
                  DocumentTemplateName = template.Name
               });
            });
         }

         return Task.FromResult(new BaseResponse<List<DocumentDTO>>(true, "User documents retrieved successfully", documentsDTO));
      }
   }
}