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

    public class EducationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserService userService;
        public EducationService(IUnitOfWork unitOfWork, UserService userService)
        {
            _unitOfWork = unitOfWork;
            this.userService = userService;

        }

        public async Task<Result> UpdateEducationAsync(int id, Education updatedEducation,string ApplicationUserID)
        {

            var education = await _unitOfWork.Education.GetEducationByIdAndUserAsync(id, ApplicationUserID);
            if (education == null)
                return Result.Failure("Education not found or access denied");

            education.Institution = updatedEducation.Institution;
            education.StartDate = updatedEducation.StartDate;
            education.EndDate = updatedEducation.EndDate;
            education.Degree = updatedEducation.Degree;
            education.FieldOfStudy = updatedEducation.FieldOfStudy;

            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Education updated successfully");
        }

        public async Task<Result> DeleteEducationAsync(string ApplicationUserID , int educationId)
        {
            var education = await _unitOfWork.Education.GetEducationByIdAndUserAsync(educationId, ApplicationUserID);
            if (education == null)
                return Result.Failure("Education not found");


            _unitOfWork.Education.Remove(education);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Education deleted successfully");
        }

        public async Task<Result> CreateEducationAsync(string ApplicationUserID, Education education)
        {
            var user = await userService.GetUserByEmailOrIdAsync(ApplicationUserID);
            if (user == null)
                return Result.Failure("User Not found");

            user.EducationHistory.Add(education);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Experience Added successfully");
        }

    }
}
