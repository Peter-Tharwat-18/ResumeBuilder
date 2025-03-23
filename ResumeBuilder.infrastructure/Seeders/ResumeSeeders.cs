using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ResumeBuilder.infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResumeBuilder.Domain.Entities;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.EntityFrameworkCore;

namespace ResumeBuilder.Infrastructure.Seeders
{
    public class ResumeSeeders : IResumeSeeders
    {
        ResumeBuilderDBContext context;
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        public ResumeSeeders(ResumeBuilderDBContext context,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
       public async Task Seed()
        {
            string[] roles = { "Admin", "User" };


            await context.Database.MigrateAsync();

            if (await context.Database.CanConnectAsync())
            {

                
                foreach (string role in roles)
                {
                    var roleExists = await roleManager.RoleExistsAsync(role);
                    if (!roleExists)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }

                if (!context.Users.Any())
                {
                    var user = new ApplicationUser
                    {
                        UserName = "test",
                        Email = "test@gmail.com",
                        NormalizedUserName = "TEST",
                        NormalizedEmail = "TEST@EXAMPLE.COM",
                        EmailConfirmed = true,
                        PersonalInfo = new Domain.Models.PersonalInformation
                        {
                            FirstName = "Peter",
                            Jobtitle= "Software",
                            LastName="Tharwat",
                            Address= new Domain.Models.Address
                            {
                                City="Cairo",
                                FullAdress="Cairo,Egypt",
                                State="Cairo",
                                ZipCode="123"
                            }
                        }
                    };

                    string password = "Admin123!@#";
                    var result = await userManager.CreateAsync(user, password);


                    if (result.Succeeded)
                    {
                        if (await roleManager.RoleExistsAsync("User"))
                        {
                            await userManager.AddToRoleAsync(user, "User");
                        }
                       
                        string userId = user.Id;

                        context.Certifications.AddRange(
                            new Certification {  Name = "AWS Certified Developer", Issuer = "Amazon", DateIssued = DateTime.UtcNow, ExpiryDate = DateTime.UtcNow.AddYears(3), ApplicationUserID = userId },
                            new Certification {  Name = "Microsoft Certified: Azure Fundamentals", Issuer = "Microsoft", DateIssued = DateTime.UtcNow, ExpiryDate = null, ApplicationUserID = userId }
                        );

                        context.Educations.AddRange(
                            new Education {  Institution = "Harvard University", Degree = "BSc", FieldOfStudy = "Computer Science", StartDate = DateTime.UtcNow.AddYears(-10), EndDate = DateTime.UtcNow.AddYears(-6), ApplicationUserID = userId }
                        );

                        context.Experiences.AddRange(
                            new Experience { Company = "Google", Position = "Software Engineer", Description = "Developed scalable cloud solutions.", StartDate = DateTime.UtcNow.AddYears(-3), EndDate = DateTime.UtcNow, ApplicationUserID = userId }
                        );

                        await context.SaveChangesAsync();
                    }
                }
            }


        }


    }
}

