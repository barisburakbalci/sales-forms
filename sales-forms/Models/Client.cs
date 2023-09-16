namespace sales_forms.Models
{
    public class Client
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Form>? Forms { get; }
    }
}