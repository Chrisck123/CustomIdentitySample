using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Decorators.Interface
{
    public interface ICustomUserDecorator
    {
        Task<IdentityResult> CreateAsync(ApplicationUser user);

        Task<IdentityResult> DeleteAsync(ApplicationUser user);

        Task<ApplicationUser> FindByIdAsync(string userId);

        Task<ApplicationUser> FindByNameAsync(string userName);
    }
}
