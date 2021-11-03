using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Language : BaseEntity<int>
    {
        public string? Name { get; set; } = string.Empty;

        public virtual ICollection<Staff> Staffs { set; get; } = new HashSet<Staff>();
    }
}
