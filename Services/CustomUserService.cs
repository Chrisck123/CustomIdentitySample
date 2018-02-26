using Models;
using Models.Interface;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CustomUserService : ICustomUserService
    {
        #region 建構子
        public CustomUserService(IRepository<CustomUser> repository) 
            => _repository = repository;
        #endregion

        #region 解構子
        ~CustomUserService()
            => Dispose(false);
        #endregion

        #region IDisposable Support
        private bool disposedValue = false; // 偵測多餘的呼叫
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _repository.Dispose();
                    GC.SuppressFinalize(this);
                }
                disposedValue = true;
            }
        }
        public void Dispose() 
            => Dispose(true);
        #endregion

        #region 欄位
        private IRepository<CustomUser> _repository;
        #endregion

        public Task CreateAsync(CustomUser instance)
            => _repository.CreateAsync(instance);

        public Task DeleteAsync(CustomUser instance)
            => _repository.DeleteAsync(instance);

        public IEnumerable<CustomUser> FindAll()
            => _repository.FindAll();

        public Task<CustomUser> FindAsync(Expression<Func<CustomUser, bool>> predicate)
            => _repository.FindAsync(predicate);

        public Task UpdateAsync(CustomUser instance)
            => _repository.UpdateAsync(instance);
    }
}
