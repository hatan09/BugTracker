using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class App : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string LogoURL { get; set; } = string.Empty;

        public ICollection<StaffApp>? StaffApps { get; set; } = new HashSet<StaffApp>();
    }
}
