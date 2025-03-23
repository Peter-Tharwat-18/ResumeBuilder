using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Contracts
{
    public interface IEducationRepository : IRepository<Education,int>
    {
        Task<Education?> GetEducationByIdAndUserAsync(int educationId, string userId);
    }
}
