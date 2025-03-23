using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Models
{
    [Owned]
    public class PersonalInformation
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Jobtitle { get; set; } = string.Empty;
        public Address Address { get; set; } = new();
    }
}
