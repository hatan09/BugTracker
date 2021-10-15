using BugTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<RoleDTO>))]
    public class RoleDTO : BaseDTO<string>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
