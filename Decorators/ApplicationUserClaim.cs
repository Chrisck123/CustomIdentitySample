using System;
using System.Collections.Generic;
using System.Text;

namespace Decorators
{
    public class ApplicationUserClaim
    {
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }
        public virtual int Id { get; set; }
        public virtual string UserId { get; set; }
    }
}
