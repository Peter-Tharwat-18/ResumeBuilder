
using AutoMapper;
using ResumeBuilder.Application.Common;
using ResumeBuilder.Application.DTOs;
using ResumeBuilder.Application.Validators;
using ResumeBuilder.Domain.Contracts;
using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ResumeBuilder.Application.Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidator _validator;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IValidator validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<ApplicationUser?> GetUserByEmailOrIdAsync(string paramter)
        {
            if (_validator.IsValidEmail(paramter))
            {
                return (await _unitOfWork.Users.GetUserByEmailOrIdAsync(x => x.Email == paramter));

            }
            else if (_validator.IsValidGuid(paramter))
            {
                return (await _unitOfWork.Users.GetUserByEmailOrIdAsync(x => x.Id == paramter));

            }
            return null;
        }

        public async Task<ApplicationUserDto?> GetUserDtoByEmailOrIdAsync(string paramter)
        {
            if (_validator.IsValidEmail(paramter))
            {
                return (_mapper.Map<ApplicationUserDto>(await _unitOfWork.Users.GetUserByEmailOrIdAsync(x => x.Email == paramter)));

            }
            else if (_validator.IsValidGuid(paramter))
            {
                return (_mapper.Map<ApplicationUserDto>(await _unitOfWork.Users.GetUserByEmailOrIdAsync(x => x.Id == paramter)));

            }
            return null;
        }

        public async Task<Result> UpdateUserAsync(ApplicationUserDto updatedUser, string ApplicationUserId)
        {

            var user = await _unitOfWork.Users.GetByIdAsync(ApplicationUserId);
            if (user == null)
                return Result.Failure("User not found or access denied");

            _mapper.Map(updatedUser, user);

            _unitOfWork.Users.UpdateAsync(user);

            await _unitOfWork.SaveChangesAsync();
            return Result.Success("User updated successfully");
        }
    }
}
