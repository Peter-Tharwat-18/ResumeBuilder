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
    public class SkilleRepository : Repository<Skille, int>, ISkilleRepository
    {
        ResumeBuilderDBContext _context;

        public SkilleRepository(ResumeBuilderDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Skille?> GetSkilleByIdAndUserAsync(int skilleId, string userId)
        {
            return await _context.Skilles
         .FirstOrDefaultAsync(e => e.Id == skilleId && e.ApplicationUserID == userId);
        }
    }
}
