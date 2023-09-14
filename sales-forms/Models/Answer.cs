namespace sales_forms.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public required Participant Participant { get; set; }
        public required Question Question { get; set; }
        public required string value { get; set; }
        public int Weight { get; set; }
    }
}