using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Company : BaseEntity<int>
    {
        public string? Guid { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string? LogoURL { get; set; } = string.Empty;

        public string? AdminId { get; set; } = string.Empty;
        public virtual Admin? Admin { get; set; }


        public virtual ICollection<App> Apps { get; set; } = new HashSet<App>();
        public virtual ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();

        
    }
}
