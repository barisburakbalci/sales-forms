namespace SalesForms.Entities
{
    public class Option : BaseEntity
    {
        public Question? Question { get; set; }
        public required string Value { get; set; }
        public required int Weight { get; set; }
    }
}
