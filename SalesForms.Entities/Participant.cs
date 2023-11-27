namespace SalesForms.Entities
{
    public class Participant : BaseEntity
    {
        public required string Name { get; set; }
        public ICollection<Answer>? Answers { get; }
    }
}
