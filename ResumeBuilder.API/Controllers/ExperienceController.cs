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
    [Authorize(Roles = "User")]
    public class ExperienceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ExperienceService _experienceService;

        public ExperienceController(ExperienceService experienceService,IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _experienceService = experienceService;
        }

        [HttpGet("{experienceId}")]
        public async Task<IActionResult> Get(int experienceId)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var experience = await _unitOfWork.Experience.GetExperienceByIdAndUserAsync(experienceId,CheckLoginUser());
            if (experience == null)
                return NotFound("experience not found");

            return Ok(experience);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var experiences = await _unitOfWork.Experience.FindAsync(x => x.ApplicationUserID == CheckLoginUser());

            return Ok(experiences.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Experience experience)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _experienceService.CreateExperienceAsync(CheckLoginUser(), experience);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { ApplicationUserID = experience.Id }, experience);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Experience updatedExperience)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _experienceService.UpdateExperienceAsync(id, updatedExperience,CheckLoginUser());
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _experienceService.DeleteExperienceAsync(CheckLoginUser(), id);
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
