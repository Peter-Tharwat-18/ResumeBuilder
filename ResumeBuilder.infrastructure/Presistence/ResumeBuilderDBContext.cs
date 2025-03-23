using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.infrastructure.Presistence
{
    public class ResumeBuilderDBContext :IdentityDbContext<ApplicationUser>
    {
        public ResumeBuilderDBContext(DbContextOptions<ResumeBuilderDBContext> options):base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.; Database=ResumeBuilder;Trusted_Connection=True;TrustServerCertificate=Yes");
        //}

        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Skille> Skilles { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        
    }
}
