using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core.Entities
{
    public class Report : BaseEntity<int>
    {
        public string? HashTag { get; set; } = string.Empty;
    }
}
