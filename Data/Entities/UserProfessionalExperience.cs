namespace BB360TestBrief.Data.Entities
{
    public class UserProfessionalExperience : BaseEntity
    {
        public long UserId { get; set; }
        public string Organization { get; set; }
        public string JobRole { get; set; }
        public string Description { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
    }
}