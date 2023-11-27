namespace SalesForms.Entities
{
    public class Group
    {
        public required string Name { get; set; }

        public ICollection<Form>? Forms { get; }

        public ICollection<GroupPermission>? GroupPermissions { get; }
    }
}
