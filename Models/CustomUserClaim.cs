using System;
using System.Collections.Generic;

namespace Models
{
    public partial class CustomUserClaim
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public CustomUser User { get; set; }
    }
}
