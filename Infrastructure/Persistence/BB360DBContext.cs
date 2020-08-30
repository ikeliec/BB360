using System.Threading.Tasks;
using BB360TestBrief.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BB360TestBrief.Infrastructure.Persistence
{
   public class BB360DBContext : IdentityDbContext<BB360User, ApplicationRole, long>
   {
      public BB360DBContext(DbContextOptions<BB360DBContext> options) : base(options)
      {
      }

      public DbSet<BB360User> BB360Users { get; set; }
      public DbSet<ApplicationRole> ApplicationRoles { get; set; }
      public DbSet<JobApplication> JobApplications { get; set; }
      public DbSet<DocumentTemplate> DocumentTemplates { get; set; }
      public DbSet<UserProfile> UserProfiles { get; set; }
      public DbSet<UserAcademicQualification> UserAcademicQualifications { get; set; }
      public DbSet<UserProfessionalExperience> UserProfessionalExperiences { get; set; }
      public DbSet<UserDocument> UserDocuments { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);
         modelBuilder.Seed();
      }

      public Task<int> SaveChangesAsync()
      {
         return base.SaveChangesAsync();
      }
   }
}