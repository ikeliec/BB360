using System;

namespace BB360TestBrief.Data.Entities
{
   public class UserProfile : BaseEntity
   {
      public long UserId { get; set; }
      public string Gender { get; set; }
      public DateTime DateOfBirth { get; set; }
      public string Address { get; set; }
      public string Nationality { get; set; }
      public string StateOfOrigin { get; set; }
      public string LGAOfOrigin { get; set; }
      public string TownOfOrigin { get; set; }
   }
}