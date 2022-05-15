using Microsoft.EntityFrameworkCore;
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
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException(nameof(entity));
                }
                _context.Add(entity);
                await _context.SaveChangesAsync();
            }
            catch(ArgumentNullException)
            {
                throw;
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().AddRange(entities);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await Task.Run(() => _context.Set<T>().Where(expression));
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await Task.Run(() => _context.Set<T>().ToList());
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                var found = await _context.Set<T>().FindAsync(id);
                if (found == null)
                {
                    throw new ArgumentException(nameof(id));
                }
                return await Task.Run(() => found);
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task Remove(T entity)
        {
            try
            {
                await Task.Run(() => _context.Set<T>().Remove(entity));
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                await Task.Run(() => _context.RemoveRange(entities));
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }

        public async Task<T> Update(int id,T entity)
        {
            try
            {
                var found = await GetByIdAsync(id);
                if (found  == null)
                {
                    throw new ArgumentException(nameof(entity.Id));
                }
                found = entity;
                return found;
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch(DbUpdateException)
            {
                throw;
            }
        }
    }
}
