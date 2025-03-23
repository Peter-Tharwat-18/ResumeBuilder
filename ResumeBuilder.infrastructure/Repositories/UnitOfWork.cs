
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
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly ResumeBuilderDBContext _context;
        public IUserRepository Users { get; }
        public IExperienceRepository Experience { get; }
        public IEducationRepository Education { get; }
        public ICertificationRepository Certifications { get; }
        public ISkilleRepository Skilles { get; }

        public UnitOfWork(ResumeBuilderDBContext context,
                  IUserRepository userRepository,
                  IExperienceRepository experienceRepository, IEducationRepository EducationRepo,
                  ISkilleRepository skilleRepository, ICertificationRepository certificationRepository)

        {
            _context = context;
            Users = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            Experience = experienceRepository ?? throw new ArgumentNullException(nameof(experienceRepository));
            Education = EducationRepo ?? throw new ArgumentNullException();
            Skilles = skilleRepository ?? throw new ArgumentNullException();
            Certifications = certificationRepository ?? throw new ArgumentNullException();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
