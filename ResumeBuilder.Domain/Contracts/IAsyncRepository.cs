using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Domain.Contracts
{
    public interface IRepository<T , TId> where T : class , IEntity<TId>
    {
        Task<T> GetByIdAsync(TId id);
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
        void Remove(T entity);
    }
}
