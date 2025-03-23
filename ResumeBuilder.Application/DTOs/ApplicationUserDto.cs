using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Application.DTOs
{
    public class ApplicationUserDto
    {
        public string Id { get; set; }
        public string email { get; set; }
        public PersonalInformationDto PersonalInfo { get; set; }
    }
}
