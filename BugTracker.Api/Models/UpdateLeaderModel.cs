using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models
{
    public class UpdateLeaderModel
    {
        public int AppId { get; set; }
        public string LeaderId { get; set; }
    }
}
