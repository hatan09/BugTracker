using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Settings
{
    public class JwtConfig
    {
        public string JWT_Secret { get; set; } = string.Empty;
    }
}
