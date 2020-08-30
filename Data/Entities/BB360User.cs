using System;
using Microsoft.AspNetCore.Identity;

namespace BB360TestBrief.Data.Entities
{
   public class BB360User : IdentityUser<long>
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int UserType { get; set; }
      public DateTime TimeCreated { get; set; }
      public DateTime TimeUpdated { get; set; }
   }
}