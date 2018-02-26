using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IService<T>: IDisposable
    {
        Task CreateAsync(T instance);
        IEnumerable<T> FindAll();
        Task<T> FindAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(T instance);
        Task DeleteAsync(T instance);
    }
}
