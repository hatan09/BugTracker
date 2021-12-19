using BugTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<AdminDTO>))]
    public class AdminDTO : BaseDTO<string>
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Birthdate { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
