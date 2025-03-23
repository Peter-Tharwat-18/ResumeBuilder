using Microsoft.EntityFrameworkCore;
using ResumeBuilder.Domain.Contracts;
using ResumeBuilder.Domain.Shared;
using ResumeBuilder.infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Infrastructure.Repositories
{
    public class Repository<T, TId> : IRepository<T, TId> where T : class, IEntity<TId>
    {
        private readonly ResumeBuilderDBContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ResumeBuilderDBContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> GetByIdAsync(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }


        public void UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }


    }
}
