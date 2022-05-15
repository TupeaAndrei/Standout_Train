using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Standout_Train.DAL.Interfaces
{
    public interface IRepository<T> where T : class,IEntity
    {
        Task AddAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);
        Task AddRange(IEnumerable<T> entities);
        Task Remove(T entity);
        Task RemoveRange(IEnumerable<T> entities);
        Task<T> Update(int id,T entity);
    }
}
