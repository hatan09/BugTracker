using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Bug : BaseEntity
    {

        public string? Title { get; set; } = string.Empty;
        public ServerityLevel Serverity { get; set; } = ServerityLevel.SMALL;


        public virtual ICollection<Staff> Devs { get; set; } = new HashSet<Staff>();
    }

    public enum ServerityLevel { SMALL, NORMAL, BAD, EXTREME, EMERGENCY}
}
