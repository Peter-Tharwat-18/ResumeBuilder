using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Contracts
{
    public interface IExperienceRepository : IRepository<Experience,int>
    {
        Task<Experience?> GetExperienceByIdAndUserAsync(int experienceId, string userId);
    }
}
