using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Application.Validators
{
    public interface IValidator
    {
        bool IsValidEmail(string email);
        bool IsValidGuid(string input);
    }
}
