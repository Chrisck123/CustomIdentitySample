using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Models.Interface
{
    public interface IRepository<T> : IDisposable
    {
        Task CreateAsync(T instance);
        IQueryable<T> FindAll();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(T instance);
        Task DeleteAsync(T instance);
        Task SaveChangesAsync();
    }
}
