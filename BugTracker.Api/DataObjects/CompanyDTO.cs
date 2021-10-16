using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    public class CompanyDTO : BaseDTO<int>
    {
        public string? Guid { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string? LogoURL { get; set; } = string.Empty;
        public string? AdminId { get; set; } = string.Empty;
    }
}
