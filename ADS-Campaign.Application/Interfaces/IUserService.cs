using ADS_Campaign.Application.DTOs.Atuh;
using Microsoft.AspNetCore.Identity;

namespace ADS_Campaign.Application.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(RegisterDto dto);
        Task<UserDto> GetUserByIdAsync(string userId);
        Task<List<UserDto>> GetAllUsersAsync();
        Task<IdentityResult> UpdateUserAsync(string userId, UpdateUserDto dto);
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<string> GetUserRolesAsync(string userId);
    }
}
