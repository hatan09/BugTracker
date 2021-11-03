using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    public class AppDTO : BaseDTO<int>
    {

    }

    public class CreateAppDTO : AppDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LogoURL { get; set; } = string.Empty;

        [Required]
        public int CompanyId { get; set; }
    }
}
