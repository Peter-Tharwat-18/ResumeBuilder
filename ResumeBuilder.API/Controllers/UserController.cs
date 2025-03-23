using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.Application.DTOs;
using ResumeBuilder.Application.Services;
using ResumeBuilder.Domain.Contracts;
using System.Security.Claims;

namespace ResumeBuilder.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {

        private readonly UserService _userService;
        private readonly IUnitOfWork _unitOfWork;   

        public UserController(IUnitOfWork unitOfWork,UserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("User not found.");

            var userDto = await _userService.GetUserDtoByEmailOrIdAsync(userId);
            if (userDto == null)
                return NotFound("User not found.");

            return Ok(userDto);
        }

        [HttpPost("{ApplicationUserId}")]
        public async Task<IActionResult> Update(string ApplicationUserId, [FromBody] ApplicationUserDto userDto)
        {
      
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _userService.UpdateUserAsync(userDto, ApplicationUserId);
            if (result == null)
                return NotFound("User not found.");

            return NoContent();
        }


        private string? CheckLoginUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return null;
            return userId;
        }
    }
}
