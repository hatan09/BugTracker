using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Staff : User
    {
        public ICollection<StaffApp>? StaffApps { get; set; } = new HashSet<StaffApp>();
    }
}
