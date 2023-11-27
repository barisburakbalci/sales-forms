using Microsoft.AspNetCore.Identity;

namespace SalesForms.Entities.Identity
{
    public class AppUser : IdentityUser<long>
    {
        public required string Name { get; set; }
    }
}
