using BugTracker.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BugTracker.Api.DataObjects.Get
{
    [ModelBinder(typeof(MultipleSourcesModelBinder<GetCustomerDTO>))]
    public class GetCustomerDTO
    {
        public string Id { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
