namespace SalesForms.Entities
{
    public class Answer : BaseEntity
    {
        public Participant? Participant { get; set; }
        public Question? Question { get; set; }
        public Option? Option { get; set; }
    }
}
