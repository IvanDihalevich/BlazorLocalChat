using LocalChat.Core.Context;
using LocalChat.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalChat.Reposetory.CommonR
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class, IEntity<TKey>
    {
        protected readonly ChatContext _context;

        public Repository(ChatContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                await SaveAsync();
            }
        }

        public virtual async Task<TEntity> GetAsync(TKey id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
