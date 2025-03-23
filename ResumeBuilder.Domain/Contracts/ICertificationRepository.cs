using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Contracts
{
    public interface ICertificationRepository : IRepository<Certification,int>
    {
        Task<Certification?> GetCertificationByIdAndUserAsync(int certificationId, string userId);
    }
}
