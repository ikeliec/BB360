using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure;
using BB360TestBrief.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace BB360TestBrief.Core.Commands.Profile
{
   public class PostProfileCommandHandler : IRequestHandler<PostProfileCommand, BaseResponse<ProfileDTO>>
   {
      private readonly BB360DBContext _context;
      private readonly ILogger<PostProfileCommandHandler> _logger;
      private readonly UserManager<BB360User> _userManager;

      public PostProfileCommandHandler(
         BB360DBContext context,
         ILogger<PostProfileCommandHandler> logger,
         UserManager<BB360User> userManager
      )
      {
         _context = context;
         _logger = logger;
         _userManager = userManager;
      }

      public async Task<BaseResponse<ProfileDTO>> Handle(PostProfileCommand request, CancellationToken cancellationToken)
      {
         var user = await _userManager.FindByIdAsync($"{request.UserId}");

         if (user == null) return new BaseResponse<ProfileDTO>(false, "User does not exist");

         var profile = _context.UserProfiles.FirstOrDefault(p => p.UserId == request.UserId);

         if (profile == null)
         {
            //new profile
            var newProfile = new UserProfile
            {
               Address = request.Address,
               DateOfBirth = request.DateOfBirth,
               Gender = request.Gender,
               LGAOfOrigin = request.LGAOfOrigin,
               Nationality = request.Nationality,
               StateOfOrigin = request.StateOfOrigin,
               TimeCreated = DateTime.Now,
               TimeUpdated = DateTime.Now,
               TownOfOrigin = request.TownOfOrigin,
               UserId = user.Id
            };
            _context.UserProfiles.Add(newProfile);
            _context.SaveChanges();

            return new BaseResponse<ProfileDTO>(true, "Profile updated successfully", newProfile.ToDTO(user));
         }

         profile.Address = request.Address;
         profile.DateOfBirth = request.DateOfBirth;
         profile.Gender = request.Gender;
         profile.LGAOfOrigin = request.LGAOfOrigin;
         profile.Nationality = request.Nationality;
         profile.StateOfOrigin = request.StateOfOrigin;
         profile.TimeUpdated = DateTime.Now;
         profile.TownOfOrigin = request.TownOfOrigin;
         profile.UserId = user.Id;

         _context.SaveChanges();

			return new BaseResponse<ProfileDTO>(true, "Profile updated successfully", profile.ToDTO(user));
      }
   }
}