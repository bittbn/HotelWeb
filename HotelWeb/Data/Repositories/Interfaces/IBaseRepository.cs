using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelWeb.Repositories.Interfaces
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<bool> ExistById(int id);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate);
        Task<bool> Any(Expression<Func<TEntity, bool>> predicate);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Save();
    }
}
