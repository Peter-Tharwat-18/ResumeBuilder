using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResumeBuilder.Application.Services;
using ResumeBuilder.Domain.Contracts;
using ResumeBuilder.Domain.Entities;
using System.Security.Claims;

namespace ResumeBuilder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="User")]
    public class SkilleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SkilleService _skilleService;
        public SkilleController(IUnitOfWork unitOfWork, SkilleService skilleService, UserService userService)
        {
            _unitOfWork = unitOfWork;
            _skilleService = skilleService;
        }

        [HttpGet("{skilleId}")]
        public async Task<IActionResult> Get(int skilleId)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var skille = await _unitOfWork.Skilles.GetSkilleByIdAndUserAsync(skilleId,CheckLoginUser());
            if (skille == null)
                return NotFound("Skille not found");

            return Ok(skille);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var skilles = await _unitOfWork.Skilles.FindAsync(x => x.ApplicationUserID == CheckLoginUser());

            return Ok(skilles.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] Skille skille)  
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _skilleService.CreateSkilleAsync(CheckLoginUser(), skille);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { skilleId = skille.Id }, skille);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Skille updateSkill)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _skilleService.UpdateSkilleAsync(id, updateSkill, CheckLoginUser());
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _skilleService.DeleteSkilleAsync(CheckLoginUser(), id);
            if (!result.IsSuccess)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        private string? CheckLoginUser()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null) return null;
            return userId;
        }
    }
}
