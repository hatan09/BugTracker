using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.Models
{
    public class FindWithEnumValueModel
    {
        public int Id { get; set; }
        public ServerityLevel ServerityLevel { get; set; }
        public ProgressStatus ProgressStatus { get; set; }
    }
}
