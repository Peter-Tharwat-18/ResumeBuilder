using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Domain.Contracts;
using ResumeBuilder.Domain.Entities;
using ResumeBuilder.infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Infrastructure.Repositories
{
    public class UserRepository : Repository<ApplicationUser, string>, IUserRepository
    {
        private readonly ResumeBuilderDBContext _context;

        public UserRepository(ResumeBuilderDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetUserByEmailOrIdAsync(Expression<Func<ApplicationUser, bool>> predicate)
        {
            return await _context.Users
                .Include(u => u.EducationHistory)
                .Include(u => u.WorkExperiences)
                .Include(u => u.Certifications)
                .Include(u => u.Skilles)
                .Include(u=>u.PersonalInfo)
                .ThenInclude(u=>u.Address)
                .FirstOrDefaultAsync(predicate);
        }
    }
}
