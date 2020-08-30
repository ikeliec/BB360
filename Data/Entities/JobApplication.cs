namespace BB360TestBrief.Data.Entities
{
   public class JobApplication : BaseEntity
   {
      public long UserId { get; set; }
      public string JobRole { get; set; }
      public string PrimarySkills { get; set; }
      public string PortfolioLink { get; set; }
      public string LinkedInProfileLink { get; set; }
      public string NewsSource { get; set; }
      public string ReferralName { get; set; }
      public string RiskSituation { get; set; }
      public string RiskOutcome { get; set; }
      public string ProblemSolverOpinion { get; set; }
      public string Comment { get; set; }
      public bool IsSuccessful { get; set; }
   }
}