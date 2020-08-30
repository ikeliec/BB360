using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Enums;
using BB360TestBrief.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief.Core.Queries.Profile
{
   public class GetUserProfileQuery : IRequest<BaseResponse<ProfileDTO>>
   {
      public long UserId { get; set; }
      public string BaseUrl { get; set; }
   }

   public class GetUserProfileQueryHandler : IRequestHandler<GetUserProfileQuery, BaseResponse<ProfileDTO>>
   {
      private readonly BB360DBContext _context;
      private readonly ILogger<GetUserProfileQueryHandler> _logger;
      private readonly UserManager<BB360User> _userManager;

      public GetUserProfileQueryHandler(
         BB360DBContext context,
         ILogger<GetUserProfileQueryHandler> logger,
         UserManager<BB360User> userManager
      )
      {
         _context = context;
         _logger = logger;
         _userManager = userManager;
      }

      public async Task<BaseResponse<ProfileDTO>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
      {
         var user = await _userManager.FindByIdAsync($"{request.UserId}");
         var profile = _context.UserProfiles.FirstOrDefault(p => p.UserId == request.UserId);
         var academics = _context.UserAcademicQualifications.Where(a => a.UserId == request.UserId).ToList();
         var professionals = _context.UserProfessionalExperiences.Where(p => p.UserId == request.UserId).ToList();
			var documents = _context.UserDocuments.Where(d => d.UserId == request.UserId).ToList();

         var academicsDTO = new List<AcademicQualificatonDTO>();
         var professionalsDTO = new List<ProfessionalExperienceDTO>();
         var documentsDTO = new List<DocumentDTO>();

         if (academics.Any())
         {
            academics.ForEach(academic =>
            {
               academicsDTO.Add(new AcademicQualificatonDTO
               {
                  Academy = academic.Academy,
                  Certification = academic.Certification,
                  EndYear = academic.EndYear,
                  StartYear = academic.StartYear
               });
            });
         }

         if (professionals.Any())
         {
            professionals.ForEach(experience =>
				{
					professionalsDTO.Add(new ProfessionalExperienceDTO
					{
						Description = experience.Description,
						EndYear = experience.EndYear,
						JobRole = experience.JobRole,
						Organization = experience.Organization,
						StartYear = experience.StartYear
					});
				});
         }

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


         var response = new ProfileDTO
         {
            AcademicQualifications = academicsDTO,
            Address = profile?.Address,
            DateOfBirth = profile?.DateOfBirth.ToString("MMMM dd, yyyy"),
            FirstName = user?.FirstName,
            Gender = profile?.Gender,
				LastName = user?.LastName,
				LGAOfOrigin = profile?.LGAOfOrigin,
				Nationality = profile?.Nationality,
				ProfessionalExperience = professionalsDTO,
				StateOfOrigin = profile?.StateOfOrigin,
				TownOfOrigin = profile?.TownOfOrigin,
				UserType = ((UserTypeEnum)user?.UserType).GetDescription(),
				Documents = documentsDTO
         };
			return new BaseResponse<ProfileDTO>(true, "Profile information retrieved successfully", response);
      }
   }
}