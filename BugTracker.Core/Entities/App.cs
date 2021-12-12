using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class App : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;
        public string LogoURL { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public string? LeaderId { get; set; }

        public int? CompanyId { get; set; }
        public virtual Company Company { get; set; }

        public virtual ICollection<Staff>? Staffs { get; set; } = new HashSet<Staff>();
        public virtual ICollection<Report>? Reports { get; set; } = new HashSet<Report>();
        public virtual ICollection<Bug>? Bugs { get; set; } = new HashSet<Bug>();
    }
}
