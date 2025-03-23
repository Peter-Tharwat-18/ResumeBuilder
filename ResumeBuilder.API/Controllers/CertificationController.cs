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
    public class CertificationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly CertificationService _certificationService;
        public CertificationController(IUnitOfWork unitOfWork, CertificationService certificationService)
        {
            _unitOfWork = unitOfWork;
            _certificationService = certificationService;

        }


        [HttpGet("{certificationId}")]
        public async Task<IActionResult> Get(int certificationId)   
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var certification = await _unitOfWork.Certifications.GetCertificationByIdAndUserAsync(certificationId, CheckLoginUser());
            if (certification == null)
                return NotFound("Certification not found");

            return Ok(certification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");
            var certifications = await _unitOfWork.Certifications.FindAsync(x => x.ApplicationUserID == CheckLoginUser());

            return Ok(certifications.ToList());
        }

        [HttpPost("{ApplicationUserID}")]
        public async Task<IActionResult> Create([FromBody] Certification certification)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _certificationService.CreateCertificationAsync(CheckLoginUser(), certification);

            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return CreatedAtAction(nameof(Get), new { certificationId = certification.Id }, certification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Certification updateCertification)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _certificationService.UpdateCertificationAsync(id, updateCertification,CheckLoginUser());
            if (!result.IsSuccess)
                return BadRequest(result.Message);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete( int id)
        {
            if (string.IsNullOrEmpty(CheckLoginUser()))
                return Unauthorized("User not found.");

            var result = await _certificationService.DeleteCertificationAsync(CheckLoginUser(), id);
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
