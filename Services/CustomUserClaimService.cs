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
    public class CustomUserClaimService : ICustomUserClaimService
    {
        #region 建構子
        public CustomUserClaimService(IRepository<CustomUserClaim> repository)
            => _repository = repository;
        #endregion

        #region 解構子
        ~CustomUserClaimService()
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
        private IRepository<CustomUserClaim> _repository;
        #endregion
        public Task CreateAsync(CustomUser instance)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(CustomUser instance)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomUser> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomUser> FindAsync(Expression<Func<CustomUser, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CustomUser instance)
        {
            throw new NotImplementedException();
        }
    }
}
