using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief.Core.Commands.AcademicQualifications
{
   public class PostAcademicQualificationsCommandHandler : IRequestHandler<PostAcademicQualificationsCommand, BaseResponse<List<AcademicQualificatonDTO>>>
   {
      private readonly BB360DBContext _context;
      private readonly ILogger<PostAcademicQualificationsCommandHandler> _logger;

      public PostAcademicQualificationsCommandHandler(
         BB360DBContext context,
         ILogger<PostAcademicQualificationsCommandHandler> logger
      )
      {
         _context = context;
         _logger = logger;
      }
		
      public Task<BaseResponse<List<AcademicQualificatonDTO>>> Handle(PostAcademicQualificationsCommand request, CancellationToken cancellationToken)
      {
         var academicDTO = new List<AcademicQualificatonDTO>();
         if (request.Qualifications.Any())
         {
            foreach (var qualification in request.Qualifications)
            {
               var newQualification = new UserAcademicQualification
               {
                  Academy = qualification.Academy,
                  Certification = qualification.Certification,
                  EndYear = qualification.EndYear,
                  StartYear = qualification.StartYear,
                  TimeCreated = DateTime.Now,
                  TimeUpdated = DateTime.Now,
                  UserId = request.UserId
               };
               _context.UserAcademicQualifications.Add(newQualification);

               academicDTO.Add(new AcademicQualificatonDTO
               {
                  Academy = newQualification.Academy,
                  Certification = newQualification.Certification,
                  EndYear = newQualification.EndYear,
                  StartYear = newQualification.StartYear,
               });
            }
            _context.SaveChanges();

            return Task.FromResult(new BaseResponse<List<AcademicQualificatonDTO>>(true, $"Academic qualifications posted successfully", academicDTO));
         }

         return Task.FromResult(new BaseResponse<List<AcademicQualificatonDTO>>(false, $"No academic qualification provided"));
      }
   }
}