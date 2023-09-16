namespace sales_forms.Models
{
    public class Question
    {
        public int Id { get; set; }
        public required string Expression { get; set; }
        public Form Form { get; set; }
        public ICollection<Answer>? Answers { get; }
        public ICollection<Option>? Options {  get; }

    }
}
