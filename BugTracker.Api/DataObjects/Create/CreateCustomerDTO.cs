﻿using BugTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects.Create
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<CreateCustomerDTO>))]
    public class CreateCustomerDTO
    {
        public string? UserName { get; set; } = string.Empty;

        public string? Password { get; set; } = string.Empty;

        public string? FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; } = DateTime.Now;
    }
}