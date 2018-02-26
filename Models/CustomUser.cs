using System;
using System.Collections.Generic;

namespace Models
{
    public partial class CustomUser
    {
        public CustomUser()
        {
            CustomUserClaim = new HashSet<CustomUserClaim>();
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }

        public ICollection<CustomUserClaim> CustomUserClaim { get; set; }
    }
}
