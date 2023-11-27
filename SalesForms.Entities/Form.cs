namespace SalesForms.Entities
{
    public class Form : BaseEntity
    {
        public required string Name { get; set; }
        public Group? Group { get; set; }
        public ICollection<Question>? Questions { get; }
    }
}
