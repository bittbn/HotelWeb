using HotelWeb.Context;
using HotelWeb.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelWeb.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly HotelDbContext _context;

        public BaseRepository(HotelDbContext context)
        {
            _context = context;
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> GetById(int id)
        {
            return await Task.Run(() => _context.Set<TEntity>().FindAsync(id));
        }

        public async Task<bool> ExistById(int id)
        {
            return await Task.Run(() => _context.Set<TEntity>().FindAsync(id).IsCompleted);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Task.Run(() => _context.Set<TEntity>().ToListAsync());
        }

        public async Task<bool> Any(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _context.Set<TEntity>().AnyAsync(predicate));
        }

        public async Task<TEntity> GetByPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _context.Set<TEntity>().FirstOrDefaultAsync(predicate));
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
