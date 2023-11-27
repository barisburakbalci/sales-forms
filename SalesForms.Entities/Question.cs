namespace SalesForms.Entities
{
    public class Question : BaseEntity
    {
        public required string Expression { get; set; }
        public Form? Form { get; set; }
        public ICollection<Answer>? Answers { get; }
        public ICollection<Option>? Options {  get; }
    }
}
