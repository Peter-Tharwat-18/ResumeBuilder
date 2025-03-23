using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Domain.Contracts;
using ResumeBuilder.Domain.Entities;
using ResumeBuilder.infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Infrastructure.Repositories
{
    public class ExperienceRepository : Repository<Experience,int>, IExperienceRepository
    {
        private readonly ResumeBuilderDBContext _context;

        public ExperienceRepository(ResumeBuilderDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Experience?> GetExperienceByIdAndUserAsync(int experienceId, string userId)
        {
            return await _context.Experiences
          .FirstOrDefaultAsync(e => e.Id == experienceId && e.ApplicationUserID == userId);
        }
    }
}
