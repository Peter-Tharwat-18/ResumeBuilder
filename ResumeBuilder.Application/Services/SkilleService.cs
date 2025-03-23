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
    public class SkilleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserService userService;
        public SkilleService(IUnitOfWork unitOfWork, UserService userService)
        {
            _unitOfWork = unitOfWork;
            this.userService = userService;
        }

        public async Task<Result> UpdateSkilleAsync(int id, Skille updatedSkill,string ApplicationUserId)
        {

            var skille = await _unitOfWork.Skilles.GetSkilleByIdAndUserAsync(id, ApplicationUserId);
            if (skille == null)
                return Result.Failure("Skille not found or access denied");

            skille.ProficiencyLevel = updatedSkill.ProficiencyLevel;
            skille.Name= updatedSkill.Name;

            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Skille updated successfully");
        }

        public async Task<Result> DeleteSkilleAsync(string ApplicationUserID, int skillId)
        {
            var skille = await _unitOfWork.Skilles.GetSkilleByIdAndUserAsync(skillId, ApplicationUserID);
            if (skille == null)
                return Result.Failure("Skille not found");


            _unitOfWork.Skilles.Remove(skille);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Skille deleted successfully");
        }

        public async Task<Result> CreateSkilleAsync(string ApplicationUserID, Skille skille)
        {
            var user = await userService.GetUserByEmailOrIdAsync(ApplicationUserID);
            if (user == null)
                return Result.Failure("User Not found");

            user.Skilles.Add(skille);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Skille Added successfully");
        }

    }
}
