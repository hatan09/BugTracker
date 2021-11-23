using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    public class BugDTO : BaseDTO<int>
    {
        public string? Title { get; set; } = string.Empty;
        public ServerityLevel Serverity { get; set; } = ServerityLevel.SMALL;
        public ProgressStatus Status { get; set; } = ProgressStatus.WORKING;
        public string? Description { get; set; } = string.Empty;

        public int AppId { get; set; }
    }

    public class CreateBugDTO : BugDTO
    {
        public List<int> ReportIDs { get; set; } = new List<int>();
    }
}
