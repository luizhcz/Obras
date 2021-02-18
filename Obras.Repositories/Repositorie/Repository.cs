using Microsoft.EntityFrameworkCore;
using Obras.Commom.Repositorie;
using Obras.Repositories.Connection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Obras.Repositories.Repositorie
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Context _context;
        private readonly DbSet<TEntity> entities;

        public Repository(Context context)
        {
            _context = context;
            entities = _context.Set<TEntity>();
        }

        public async Task Add(TEntity entity)
        {
            entities.Add(entity);
            await SaveChanges();
        }

        public async Task<TEntity> Get()
        {
            return await entities.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await entities.AsNoTracking().ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
