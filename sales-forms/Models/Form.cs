namespace sales_forms.Models
{
    public class Form
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Client client { get; set; }
        public ICollection<Question>? Questions { get; }
    }
}