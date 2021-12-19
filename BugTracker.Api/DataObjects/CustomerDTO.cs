using BugTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    public class CustomerDTO : BaseDTO<string>
    {
        public string? UserName { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }

    [ModelBinder(typeof(MultipleSourcesModelBinder<GetCustomerDTO>))]
    public class GetCustomerDTO : BaseDTO<string>
    {
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
        public bool IsDeleted { get; set; }
    }

    [ModelBinder(typeof(MultipleSourcesModelBinder<CreateCustomerDTO>))]
    public class CreateCustomerDTO
    {
        public string? UserName { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string Birthdate { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }
    }
}
