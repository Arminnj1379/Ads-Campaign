using Microsoft.AspNetCore.Identity;

namespace ADS_Campaign.Domain.Entities.ApplicationRole
{
    public class ApplicationRole : IdentityRole
    {
        public const string Admin = "Admin";
        public const string User = "User";

        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }
}
