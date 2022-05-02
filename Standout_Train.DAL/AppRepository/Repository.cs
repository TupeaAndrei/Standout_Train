using Standout_Train.DAL.Context;
using Standout_Train.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.DAL.AppRepository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly TrainContext _context;

        public Repository(TrainContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() => _context.Set<T>().Where(expression));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<T>().ToList());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var found = await _context.Set<T>().FindAsync(id);
            if (found == null)
            {
                throw new ArgumentException(nameof(id));
            }
            return await Task.Run(() => found);
        }

        public async Task Remove(T entity)
        {
            await Task.Run(() => _context.Set<T>().Remove(entity));
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            await Task.Run(() => _context.RemoveRange(entities));
        }
    }
}
