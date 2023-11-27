using SalesForms.Entities.Identity;

namespace SalesForms.Entities
{
	public class GroupPermission : BaseEntity
    {
        public Group? Group { get; set; }
        public AppUser? AppUser { get; set; }
        public AccessType AccessType { get; set; } = AccessType.Read;
    }

    public enum AccessType
    {
        Read,
        Write,
        Delete
    }
}
