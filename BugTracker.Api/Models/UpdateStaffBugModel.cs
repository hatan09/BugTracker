using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models
{
    public class UpdateStaffBugModel
    {
        public int BugId { get; set; }
        public IEnumerable<string> StaffId { get; set; }
    }
}
