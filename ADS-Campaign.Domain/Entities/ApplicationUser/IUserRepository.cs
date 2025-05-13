namespace ADS_Campaign.Domain.Entities.ApplicationUser
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByUserNameAsync(string username);
        Task<List<ApplicationUser>> GetAllUsersAsync();
    }
}
