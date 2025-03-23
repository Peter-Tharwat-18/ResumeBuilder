using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IExperienceRepository Experience { get; }
        IEducationRepository Education { get; }
        ICertificationRepository Certifications { get; }
        ISkilleRepository Skilles { get; }

        Task<int> SaveChangesAsync();
    }
}
