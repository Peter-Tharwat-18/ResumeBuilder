using ResumeBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Contracts
{
    public interface ISkilleRepository : IRepository<Skille,int>
    {
        Task<Skille?> GetSkilleByIdAndUserAsync(int skilleId, string userId);
    }
}
