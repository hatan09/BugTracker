using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models
{
    public class UpdateBugReportModel
    {
        public int BugId { get; set; }
        public IEnumerable<int> ReportIds { get; set; }
    }
}
