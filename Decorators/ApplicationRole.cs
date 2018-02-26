using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;

namespace Decorators
{
    public class ApplicationRole
    {
        public string Id { get; set; } = $"{Guid.NewGuid()}";
        public string Name { get; set; }
    }
}
