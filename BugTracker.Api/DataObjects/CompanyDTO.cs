using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    public class CompanyDTO : BaseDTO<int>
    {
        public Guid Guid { get; set; } = Guid.Empty;
        public string Name { get; set; } = string.Empty;
        public string ShortName { get; set; } = string.Empty;
        public string? LogoURL { get; set; } = string.Empty;
        public string? AdminId { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
