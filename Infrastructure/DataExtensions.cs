using BB360TestBrief.Data.Entities;
using BB360TestBrief.Data.Models;
using BB360TestBrief.Infrastructure.Enums;

namespace BB360TestBrief.Infrastructure
{
   public static class DataExtensions
   {
      public static ProfileDTO ToDTO(this UserProfile userProfile, BB360User user)
      {
         return new ProfileDTO
         {
            Address = userProfile.Address,
            DateOfBirth = userProfile.DateOfBirth.ToString("MMMM dd, yyyy"),
            Gender = userProfile.Gender,
            LGAOfOrigin = userProfile.LGAOfOrigin,
            Nationality = userProfile.Nationality,
            StateOfOrigin = userProfile.StateOfOrigin,
            TownOfOrigin = userProfile.TownOfOrigin,
				FirstName = user.FirstName,
				LastName = user.LastName,
				UserType = ((UserTypeEnum)user.UserType).GetDescription()
         };
      }
   }
}