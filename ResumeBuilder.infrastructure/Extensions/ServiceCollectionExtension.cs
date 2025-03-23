using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ResumeBuilder.Application.Validators;
using ResumeBuilder.Domain.Contracts;
using ResumeBuilder.Domain.Entities;
using ResumeBuilder.infrastructure.Presistence;
using ResumeBuilder.Infrastructure.Repositories;
using ResumeBuilder.Infrastructure.Seeders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrStructure(this IServiceCollection service, IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("DefaultConnection");
            service.AddDbContext<ResumeBuilderDBContext>(option =>
            {
                option.UseSqlServer(ConnectionString);
            });

            service.AddScoped<IResumeSeeders, ResumeSeeders>();

            service.AddIdentityCore<ApplicationUser>().AddRoles<IdentityRole>()
                              .AddEntityFrameworkStores<ResumeBuilderDBContext>();

            service.AddScoped<IUnitOfWork, UnitOfWork>();

            service.AddScoped<IValidator, Validation>();
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IExperienceRepository, ExperienceRepository>();
            service.AddScoped<IEducationRepository, EducationRepository>();
            service.AddScoped<ISkilleRepository, SkilleRepository>();
            service.AddScoped<ICertificationRepository, CertificationRepository>();
        }
    }
}
