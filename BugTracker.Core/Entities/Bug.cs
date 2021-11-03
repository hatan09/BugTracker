using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Bug : BaseEntity<int>
    {
        public string? Title { get; set; } = string.Empty;
        public ServerityLevel Serverity { get; set; } = ServerityLevel.SMALL;
        public ProgressStatus Status { get; set; } = ProgressStatus.WORKING;
        public string? Description { get; set; } = string.Empty;

        public int AppId { get; set; }
        public App App { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    }

    public enum ServerityLevel { SMALL, NORMAL, BAD, EXTREME, EMERGENCY}
    public enum ProgressStatus { WORKING, FIXED, REVISED, APPROVED}
}
