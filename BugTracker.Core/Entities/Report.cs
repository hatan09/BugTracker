using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Report : BaseEntity<int>
    {
        public string? Title { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;

        public string CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int AppId { get; set; }
        public App App { get; set; }

        public int BugId { get; set; }
        public Bug Bug { get; set; }
    }
}
