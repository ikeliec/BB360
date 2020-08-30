using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief.Core.Commands.Documents
{
   public class UploadDocumentCommandHandler : IRequestHandler<UploadDocumentCommand, BaseResponse<string>>
   {
      private readonly BB360DBContext _context;
      private readonly ILogger<UploadDocumentCommandHandler> _logger;

      public UploadDocumentCommandHandler(
         BB360DBContext context,
         ILogger<UploadDocumentCommandHandler> logger
      )
      {
         _context = context;
         _logger = logger;
      }

      public async Task<BaseResponse<string>> Handle(UploadDocumentCommand request, CancellationToken cancellationToken)
      {
         if (request.DocumentFile.Length < 1 || request.DocumentFile == null)
            return new BaseResponse<string>(false, $"File not attached. Attach file and try again");

         //Validate file extension
         var ext = Path.GetExtension(request.DocumentFile.FileName);
         string[] formats = new string[] { ".jpg", ".jpeg", ".png", ".pdf", ".doc", ".docx" };
         if (!formats.Contains(ext))
            return new BaseResponse<string>(false, "Invalid file extension, kindly ensure file is in jpg, jpeg, png, doc, docx or pdf format");

         var template = _context.DocumentTemplates.Find(request.TemplateId);
         var dbPath = Path.Combine("Documents", $"{request.UserId}", $"{template.Name.Replace("\\", "-").Replace("/", "-")}");
         var directoryPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", dbPath);

         if (!Directory.Exists(directoryPath))
         {
            Directory.CreateDirectory(directoryPath);
         }

         var docName = DateTime.Now.ToString("yyyyMMddHHmmss");
         var path = Path.Combine(directoryPath, $"{docName}{ext}");
         var dbPathFull = Path.Combine(dbPath, $"{docName}{ext}");
         try
         {
            using (var stream = new FileStream(path, FileMode.Create))
            {
               await request.DocumentFile.CopyToAsync(stream);
            }

            var document = new UserDocument
            {
               DocumentTemplateId = request.TemplateId,
               FilePath = dbPathFull,
               Name = template.Name,
               TimeCreated = DateTime.Now,
               TimeUpdated = DateTime.Now,
               UserId = request.UserId
            };
            _context.UserDocuments.Add(document);
            _context.SaveChanges();

            return new BaseResponse<string>(true, "Document upload is successful");
         }
         catch (Exception ex)
         {
            _logger.LogError(ex, "Application ran into an error while trying to upload document");
            return new BaseResponse<string>(false, "Document upload failed. Try again.");
         }
      }
   }
}