using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models
{
    public class UpdateStaffAppModel
    {
        public bool IsLeader { get; set; } = false;
        public int AppId { get; set; }
        public string StaffId { get; set; }
    }
}
