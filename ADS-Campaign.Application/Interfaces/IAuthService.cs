using ADS_Campaign.Application.DTOs.Login;

namespace ADS_Campaign.Application.Interfaces
{
    public interface IAuthService
    {
        Task<object> LoginAsync(LoginDto loginDto);
    }
}
