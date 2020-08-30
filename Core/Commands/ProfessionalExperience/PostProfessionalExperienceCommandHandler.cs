using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief.Core.Commands.ProfessionalExperience
{
   public class PostProfessionalExperienceCommandHandler : IRequestHandler<PostProfessionalExperienceCommand, BaseResponse<List<ProfessionalExperienceDTO>>>
   {
      private readonly BB360DBContext _context;
      private readonly ILogger<PostProfessionalExperienceCommandHandler> _logger;

      public PostProfessionalExperienceCommandHandler(
         BB360DBContext context,
         ILogger<PostProfessionalExperienceCommandHandler> logger
      )
      {
         _context = context;
         _logger = logger;
      }

      public Task<BaseResponse<List<ProfessionalExperienceDTO>>> Handle(PostProfessionalExperienceCommand request, CancellationToken cancellationToken)
      {
         var professionalDTO = new List<ProfessionalExperienceDTO>();
         if (request.Experience.Any())
         {
            foreach (var experience in request.Experience)
            {
               var newExperience = new UserProfessionalExperience
               {
                  EndYear = experience.EndYear,
                  StartYear = experience.StartYear,
                  TimeCreated = DateTime.Now,
                  TimeUpdated = DateTime.Now,
                  UserId = request.UserId,
						Description = experience.Description,
						JobRole = experience.JobRole,
						Organization = experience.Organization
               };
               _context.UserProfessionalExperiences.Add(newExperience);

               professionalDTO.Add(new ProfessionalExperienceDTO
               {
                  EndYear = experience.EndYear,
                  StartYear = experience.StartYear,
						Description = experience.Description,
						JobRole = experience.JobRole,
						Organization = experience.Organization
               });
            }
            _context.SaveChanges();

            return Task.FromResult(new BaseResponse<List<ProfessionalExperienceDTO>>(true, $"Professional experience posted successfully", professionalDTO));
         }

         return Task.FromResult(new BaseResponse<List<ProfessionalExperienceDTO>>(false, $"No professional experience provided"));
      }
   }
}