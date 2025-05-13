using Microsoft.AspNetCore.Identity;

namespace ADS_Campaign.Domain.Entities.ApplicationUser
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
