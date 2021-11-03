using System.Collections.Generic;

namespace BugTracker.Core.Entities
{
    public class Customer : User
    {
        public virtual ICollection<Report> Reports { get; set; } = new HashSet<Report>();
    }
}
