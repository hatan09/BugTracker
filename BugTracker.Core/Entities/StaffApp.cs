using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class StaffApp
    {
        public bool IsLeader { get; set; } = false;

        public Staff Staff { get; set; }
        public string StaffId { get; set; }

        public App App { get; set; }
        public int AppId { get; set; }

    }
}
