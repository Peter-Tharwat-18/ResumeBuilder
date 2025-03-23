using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    public class CertificationRepository : Repository<Certification,int>, ICertificationRepository
    {
        ResumeBuilderDBContext _context;
        public CertificationRepository(ResumeBuilderDBContext context):base(context) { 
        _context = context;
        }

        public async Task<Certification?> GetCertificationByIdAndUserAsync(int certificationId, string userId)
        {
            return await _context.Certifications.FirstOrDefaultAsync(e => e.Id == certificationId && e.ApplicationUserID == userId);
        }
    }
}
