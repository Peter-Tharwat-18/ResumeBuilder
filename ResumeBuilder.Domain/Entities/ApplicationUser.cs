using Microsoft.AspNetCore.Identity;
using ResumeBuilder.Domain.Models;
using ResumeBuilder.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Entities
{
    public class ApplicationUser : IdentityUser,    IEntity<string>
    {
        public PersonalInformation PersonalInfo { get; set; } = new PersonalInformation();
        public List<Education> EducationHistory { get; set; } = new List<Education>();
        public List<Experience> WorkExperiences { get; set; }= new List<Experience>();
        public List<Skille> Skilles { get; set; } = new List<Skille>();
        public List<Certification> Certifications { get; set; } = new List<Certification>();
    }




}
