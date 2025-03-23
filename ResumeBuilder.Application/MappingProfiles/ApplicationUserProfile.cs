using AutoMapper;
using ResumeBuilder.Application.DTOs;
using ResumeBuilder.Domain.Entities;
using ResumeBuilder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Application.MappingProfiles
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>()
       .ForMember(dest => dest.PersonalInfo, opt => opt.MapFrom(src => src.PersonalInfo));


            CreateMap<PersonalInformation, PersonalInformationDto>();
            CreateMap<Address, AddressDto>();
        }
    }
}
