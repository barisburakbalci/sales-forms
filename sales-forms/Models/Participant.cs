namespace sales_forms.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Answer>? Answers { get; }
        public int Score { get; set; }
    }
}