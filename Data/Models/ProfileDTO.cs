using System.Collections.Generic;

namespace BB360TestBrief.Data.Models
{
   public class ProfileDTO
   {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string UserType { get; set; }
      public string Gender { get; set; }
      public string DateOfBirth { get; set; }
      public string Address { get; set; }
      public string Nationality { get; set; }
      public string StateOfOrigin { get; set; }
      public string LGAOfOrigin { get; set; }
      public string TownOfOrigin { get; set; }
      public List<AcademicQualificatonDTO> AcademicQualifications { get; set; }
      public List<ProfessionalExperienceDTO> ProfessionalExperience { get; set; }
      public List<DocumentDTO> Documents { get; set; }
   }

   public class AcademicQualificatonDTO
   {
      public string Academy { get; set; }
      public string Certification { get; set; }
      public string StartYear { get; set; }
      public string EndYear { get; set; }
   }

   public class ProfessionalExperienceDTO
   {
      public string Organization { get; set; }
      public string JobRole { get; set; }
      public string Description { get; set; }
      public string StartYear { get; set; }
      public string EndYear { get; set; }
   }
}