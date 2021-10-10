using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Dev : User
    {
        public ICollection<AppDev>? AppDevs { get; set; } = new HashSet<AppDev>();
    }
}
