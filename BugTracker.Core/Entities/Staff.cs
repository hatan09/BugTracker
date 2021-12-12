using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Staff : User
    {
        public int? CompanyId { get; set; }
        public Company? Company { get; set; }
        public virtual ICollection<App>? Apps { get; set; } = new HashSet<App>();
        public virtual ICollection<Bug>? Bugs { get; set; } = new HashSet<Bug>();
        public virtual ICollection<Skill> Skills { set; get; } = new HashSet<Skill>();
        public virtual ICollection<Language> Languages { set; get; } = new HashSet<Language>();

    }
}
