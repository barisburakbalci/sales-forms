namespace sales_forms.Models
{
    public class Question
    {
        public int Id { get; set; }
        public required string Expression { get; set; }
        public required Form Form { get; set; }
        public ICollection<Answer>? Answers { get; set; }
        public ICollection<Option>? Options {  get; set; }

    }
}
