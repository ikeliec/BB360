namespace BB360TestBrief.Data.Entities
{
    public class UserDocument : BaseEntity
    {
        public long UserId { get; set; }
        public long DocumentTemplateId { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
    }
}