using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Contracts
{
    public interface IUserRepository : IRepository<ApplicationUser,string>
    {
        Task<ApplicationUser?> GetUserByEmailOrIdAsync(Expression<Func<ApplicationUser, bool>> expression);
    }
}
