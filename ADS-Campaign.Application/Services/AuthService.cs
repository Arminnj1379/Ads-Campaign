using ADS_Campaign.Application.DTOs.Login;
using System.Security.Claims;
using System.Text;
using ADS_Campaign.Application.Interfaces;
using ADS_Campaign.Domain.Entities.ApplicationUser;
using ADS_Campaign.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ADS_Campaign.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;
        public AuthService(IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<object> LoginAsync(LoginDto loginDto)
        {
            var user = await _unitOfWork.UserRepository.GetUserByUserNameAsync(loginDto.UserName);
            if (user == null)
                throw new Exception("نام کاربری یا رمز عبور اشتباه است");

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
                throw new Exception("نام کاربری یا رمز عبور اشتباه است");

            // تولید JWT Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new { Succeeded = result.Succeeded, Token = tokenString, UserName = user.UserName };
        }
    }
}
