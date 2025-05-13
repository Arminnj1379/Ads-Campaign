using ADS_Campaign.Domain.Entities.ApplicationRole;
using Microsoft.AspNetCore.Identity;

namespace ADS_Campaign.Infrastructure.Persistance.Sql.Identity
{
    public class RoleSeeder
    {
        private readonly RoleManager<ApplicationRole> _roleManager;

        public RoleSeeder(RoleManager<ApplicationRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task SeedRolesAsync()
        {
            await CreateRoleIfNotExists(ApplicationRole.Admin);
            await CreateRoleIfNotExists(ApplicationRole.User);
        }

        private async Task CreateRoleIfNotExists(string roleName)
        {
            if (!await _roleManager.RoleExistsAsync(roleName))
            {
                await _roleManager.CreateAsync(new ApplicationRole(roleName));
            }
        }
    }
}
