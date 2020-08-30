using System;

namespace BB360TestBrief.Data.Entities
{
   public class BaseEntity
   {
      public long Id { get; set; }
      public DateTime TimeCreated { get; set; }
      public DateTime TimeUpdated { get; set; }
   }
}