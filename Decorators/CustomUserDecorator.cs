using Decorators.Interface;
using Microsoft.AspNetCore.Identity;
using Models;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Decorators
{
    public class CustomUserDecorator : ICustomUserDecorator
    {
        public CustomUserDecorator(ICustomUserService service)
        {
            _service = service;
        }

        private ICustomUserService _service;

        public Task<IdentityResult> CreateAsync(ApplicationUser user)
        {
            try
            {
                _service.CreateAsync(GetCustomUser(user));
                return Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Description = $"Could not insert user {user.Email}.\r\n {ex.Message}" }));
            }
        }

        public Task<IdentityResult> DeleteAsync(ApplicationUser user)
        {
            try
            {
                _service.DeleteAsync(GetCustomUser(user));
                return Task.FromResult(IdentityResult.Success);
            }
            catch (Exception ex)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError { Description = $"Could not delete user {user.Email}.r\n {ex.Message}" }));
            }
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId)
            => GetApplicationUser(await _service.FindAsync(p => $"{ p.Id}" == userId));

        public async Task<ApplicationUser> FindByNameAsync(string userName)
            => GetApplicationUser(await _service.FindAsync(p => p.UserName == userName));

        private CustomUser GetCustomUser(ApplicationUser user)
            => user == null ? null : new CustomUser()
            {
                Id = Guid.Parse(user.Id),
                Email = user.Email,
                EmailConfirmed = user.EmailConfirmed,
                PasswordHash = user.PasswordHash,
                UserName = user.UserName
            };
        private ApplicationUser GetApplicationUser(CustomUser user)
         => user == null ? null : new ApplicationUser()
         {
             Id = $"{user.Id}",
             UserName = user.UserName
         };
    }
}
