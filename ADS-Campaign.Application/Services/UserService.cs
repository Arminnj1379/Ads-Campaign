using ADS_Campaign.Application.DTOs.Atuh;
using ADS_Campaign.Application.Interfaces;
using ADS_Campaign.Domain.Entities.ApplicationRole;
using ADS_Campaign.Domain.Entities.ApplicationUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ADS_Campaign.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUserAsync(RegisterDto dto)
        {
            var user = new ApplicationUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FullName = dto.FirstName + " " + dto.LastName,
                PhoneNumber = dto.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, ApplicationRole.User);
            }
            return result;
        }

        public async Task<UserDto> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return null;
            var userRole = await GetUserRolesAsync(userId);
            return new UserDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Role = userRole,
                PhoneNumber = user.PhoneNumber,
                FullName = user.FullName
            };
        }

        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var userDtos = new List<UserDto>();

            foreach (var user in users)
            {
                var role = await GetUserRolesAsync(user.Id);

                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    Role = role,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber
                });
            }
            return userDtos;
        }

        public async Task<string> GetUserRolesAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                throw new ArgumentException("کاربری با این ID یافت نشد.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }

        public async Task<IdentityResult> UpdateUserAsync(string userId, UpdateUserDto dto)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            user.UserName = dto.UserName ?? user.UserName;
            user.Email = dto.Email ?? user.Email;

            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            return await _userManager.DeleteAsync(user);
        }

        public async Task AddOrRemoveAdmin(string userid)
        {
            var user = await _userManager.FindByIdAsync(userid);
            var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
            if(userRole == ApplicationRole.User)
            {
                await _userManager.RemoveFromRoleAsync(user, ApplicationRole.User);
                await _userManager.AddToRoleAsync(user, ApplicationRole.Admin);
            }
            else
            {
                await _userManager.RemoveFromRoleAsync(user, ApplicationRole.Admin);
                await _userManager.AddToRoleAsync(user, ApplicationRole.User);
            }
        }
    }
}
