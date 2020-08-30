namespace BB360TestBrief.Data.Entities
{
    public class UserAcademicQualification : BaseEntity
    {
        public long UserId { get; set; }
        public string Academy { get; set; }
        public string Certification { get; set; }
        public string StartYear { get; set; }
        public string EndYear { get; set; }
    }
}