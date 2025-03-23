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
    public class CertificationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserService userService;
        public CertificationService(IUnitOfWork unitOfWork, UserService userService)
        {
            _unitOfWork = unitOfWork;
            this.userService = userService;
        }

        public async Task<Result> UpdateCertificationAsync(int id, Certification updatedCertification,string ApplicationUserID)
        {

            var certification = await _unitOfWork.Certifications.GetCertificationByIdAndUserAsync(id,ApplicationUserID);
            if (certification == null)
                return Result.Failure("Certification not found or access denied");
            certification.ExpiryDate = updatedCertification.ExpiryDate;
            certification.Issuer = updatedCertification.Issuer;
            certification.DateIssued = updatedCertification.DateIssued;
            certification.Name = updatedCertification.Name;

            await _unitOfWork.SaveChangesAsync();
            return Result.Success("Certification updated successfully");
        }

        public async Task<Result> DeleteCertificationAsync(string ApplicationUserID, int certificationId)
        {
            var certification = await _unitOfWork.Certifications.GetCertificationByIdAndUserAsync(certificationId, ApplicationUserID);
            if (certification == null)
                return Result.Failure("Certification not found");


            _unitOfWork.Certifications.Remove(certification);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Certification deleted successfully");
        }

        public async Task<Result> CreateCertificationAsync(string ApplicationUserID, Certification certification)
        {
            var user = await userService.GetUserByEmailOrIdAsync(ApplicationUserID);
            if (user == null)
                return Result.Failure("User Not found");

            user.Certifications.Add(certification);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success("Certification Added successfully");
        }

    }
}
