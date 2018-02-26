using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Decorators
{
    public class ApplicationUser : IIdentity
    {
        public virtual string Id { get; set; } = $"{ Guid.NewGuid()}";
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual bool EmailConfirmed { get; set; }
        public virtual String PasswordHash { get; set; }
        public string NormalizedUserName { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Name { get; set; }
    }
}
