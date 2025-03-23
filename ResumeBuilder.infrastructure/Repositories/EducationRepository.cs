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
    public class EducationRepository : Repository<Education, int>, IEducationRepository
    {
        ResumeBuilderDBContext _context;
        public EducationRepository(ResumeBuilderDBContext context):base(context) 
        {
            _context = context;
        }

        public async Task<Education?> GetEducationByIdAndUserAsync(int educationId, string userId)
        {
            return await _context.Educations
          .FirstOrDefaultAsync(e => e.Id == educationId && e.ApplicationUserID == userId);
        }

    }
}
