using System;
using BB360TestBrief.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BB360TestBrief.Infrastructure.Persistence
{
   public static class Extensions
   {
      public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
      {
         services.AddDbContext<BB360DBContext>(option =>
         {
            option.UseSqlServer(configuration.GetConnectionString("BB360DbConnectionString"));
         });

         return services;
      }
   }

   public static class ModelBuilderExtensions
   {
      public static void Seed(this ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<DocumentTemplate>().HasData(
            new DocumentTemplate { Id = 1, Name = "Curriculum Vitae (CV)", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 2, Name = "Employment Offer Letter", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 3, Name = "NYSC Discharge Certificate", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 4, Name = "Tertiary Certificata", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 5, Name = "WAEC/NECO Certificate", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 6, Name = "Birth Certificate", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 7, Name = "Guarantor Form", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 8, Name = "Passport Photograph", FilePath = null, TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },

            new DocumentTemplate { Id = 9, Name = "Dress Code Policy", FilePath = "Templates/DRESS CODE POLICY,pdf", TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 10, Name = "Employee Handbook", FilePath = "Templates/EMPLOYEE HANDBOOK.pdf", TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 11, Name = "Company Culture", FilePath = "Templates/COMPANY CULTURE.pdf", TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 12, Name = "Code of Conduct Policy", FilePath = "Templates/CODE OF CONDUCT POLICY.pdf", TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 13, Name = "Anti-Bribery and Corruption Policy", FilePath = "Templates/ANTI-BRIBERY AND CORRUPTION.pdf", TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 14, Name = "Whistle Blowing Policy", FilePath = "Templates/WHISTLE BLOWING POLICY.pdf", TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now },
            new DocumentTemplate { Id = 15, Name = "AML-CFT Policy", FilePath = "Templates/AML-CFT POLICY.pdf", TimeCreated = DateTime.Now, TimeUpdated = DateTime.Now }
         );
      }
   }
}