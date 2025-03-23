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
    public class EducationController : Controller
    {
       
        private readonly IUnitOfWork _unitOfWork;      
        private readonly EducationService _educationService;      
        public EducationController(IUnitOfWork unitOfWork, EducationService educationService)
        {
            _unitOfWork = unitOfWork;
            _educationService = educationService;

        }

        [HttpGet("{educationId}")]
        public async Task<IActionResult> Get(int educationId)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var education = await _unitOfWork.Education.GetEducationByIdAndUserAsync(educationId, CheckLoginUser());
            if (education == null)
                return NotFound("Education not found");

            return Ok(education);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var educations = await _unitOfWork.Education.FindAsync(x => x.ApplicationUserID == CheckLoginUser());
            
            return Ok(educations.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Create( [FromBody] Education education)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _educationService.CreateEducationAsync(CheckLoginUser(), education);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { educationId = education.Id }, education);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Education updateEducation)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _educationService.UpdateEducationAsync(id,updateEducation,CheckLoginUser());
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _educationService.DeleteEducationAsync(CheckLoginUser(), id);
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
