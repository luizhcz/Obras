using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Obras.Commom.Repositorie
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get();
        Task Add(TEntity entity);
        Task<int> SaveChanges();
    }
}
