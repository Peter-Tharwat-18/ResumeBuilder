using ResumeBuilder.Application.Common;
using ResumeBuilder.Domain.Contracts;
using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Application.Services
{
    public class ExperienceService
    {

        public readonly IUnitOfWork _unitOfWork;
        private readonly UserService _userService;

        public ExperienceService(IUnitOfWork unitOfWork, UserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<Result> UpdateExperienceAsync(int id, Experience updatedExperience,string ApplicationUserID)
        {

            var experience = await _unitOfWork.Experience.GetExperienceByIdAndUserAsync(id, updatedExperience.ApplicationUserID);
            if (experience == null)
                return Result.Failure("Experience not found or access denied");

            experience.Company = updatedExperience.Company;
            experience.Position = updatedExperience.Position;
            experience.Description = updatedExperience.Description;
            experience.StartDate = updatedExperience.StartDate;
            experience.EndDate = updatedExperience.EndDate;

            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Experience updated successfully");
        }

        public async Task<Result> DeleteExperienceAsync(string ApplicationUserId, int experienceId)
        {
            var experience = await _unitOfWork.Experience.GetExperienceByIdAndUserAsync(experienceId, ApplicationUserId);
            if (experience == null)
                return Result.Failure("Experience not found");


            _unitOfWork.Experience.Remove(experience);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Experience deleted successfully");
        }

        public async Task<Result> CreateExperienceAsync(string ApplicationUserID, Experience experience)
        {
            var user = await _userService.GetUserByEmailOrIdAsync(ApplicationUserID);
            if (user == null)
                return Result.Failure("User Not found");

            user.WorkExperiences.Add(experience);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Experience deleted successfully");
        }


    }
}
