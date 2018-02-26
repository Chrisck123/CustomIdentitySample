using Microsoft.EntityFrameworkCore;
using Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Models.Implement
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        #region 建構子
        public GenericRepository() { }
        public GenericRepository(DbContext context)
            => _context = context;
        public GenericRepository(CustomProviderContext context)
            => _context = context;
        #endregion

        #region 解構子
        ~GenericRepository()
            => Dispose(true);
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    this._context.Dispose();
                    this._context = null;
                    GC.SuppressFinalize(this);
                }
                disposedValue = true;
            }
        }
        public void Dispose()
            => Dispose(true);
        #endregion

        #region 欄位
        private DbContext _context;
        #endregion

        #region 實作
        public Task CreateAsync(T instance)
        {
            _context.Set<T>().AddAsync(instance);
            return SaveChangesAsync();
        }
        public Task<T> FindAsync(Expression<Func<T, bool>> predicate)
            => _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        public IQueryable<T> FindAll()
            => _context.Set<T>().AsNoTracking().AsQueryable();
        public Task UpdateAsync(T instance)
        {
            _context.Entry(instance).State = EntityState.Modified;
            return SaveChangesAsync();
        }
        public Task DeleteAsync(T instance)
        {
            _context.Entry(instance).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
        public Task SaveChangesAsync()
            => _context.SaveChangesAsync();
        #endregion
    }
}
