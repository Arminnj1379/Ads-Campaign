using ADS_Campaign.Application.DTOs.Atuh;
using ADS_Campaign.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ADS_Campaign.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Create")]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] RegisterDto dto)
        {
            var result = await _userService.CreateUserAsync(dto);
            if (result.Succeeded) return Ok("User created");
            return BadRequest(result.Errors);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] string id, [FromBody] UpdateUserDto dto)
        {
            var result = await _userService.UpdateUserAsync(id, dto);
            if (result.Succeeded) return Ok("User updated");
            return BadRequest(result.Errors);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (result.Succeeded) return Ok("User deleted");
            return BadRequest(result.Errors);
        }

        [HttpPost("AddOrRemoveAdmin")]
        public async Task<IActionResult> AddOrRemoveAdmin([FromQuery] string userid)
        {
            await _userService.AddOrRemoveAdmin(userid);
            return Ok();
        }
        [HttpGet("GetLoggedInUser")]
        public async Task<IActionResult> GetLoggedInUser()
        {
            string UserId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var user = await _userService.GetUserByIdAsync(UserId);
            return Ok(user);
        }
    }
}
