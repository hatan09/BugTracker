using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{

    public class ReportDTO : BaseDTO<int>
    {
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public string CustomerId { get; set; }

        public int AppId { get; set; }
    }
}
