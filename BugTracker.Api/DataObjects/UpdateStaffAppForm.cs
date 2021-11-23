using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    public class UpdateStaffAppForm
    {
        public int AppId { get; set; }
        public string StaffId { get; set; }
    }
}
