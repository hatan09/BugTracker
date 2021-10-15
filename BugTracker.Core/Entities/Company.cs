using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string? LogoURL { get; set; } = string.Empty;


        public virtual ICollection<App> Apps { get; set; } = new HashSet<App>();
        public virtual ICollection<Staff> Devs { get; set; } = new HashSet<Staff>();

        
    }
}
