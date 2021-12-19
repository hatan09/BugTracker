using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models
{
    public class UpdateStaffAppModel
    {
        public int AppId { get; set; }
        public IEnumerable<string> StaffIds { get; set; }
    }
}
