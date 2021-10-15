using AutoMapper;
using BugTracker.Api.DataObjects.Create;
using BugTracker.Api.DataObjects.Get;
using BugTracker.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Api.DataObjects
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>()
                .ForMember(d => d.Id, opt => opt.Ignore());

            CreateMap<User, UserDTO>()
                .ForMember(d => d.Roles, opt => opt.MapFrom(s => s.UserRoles.Select(ur => ur.Role!.Name)));
            CreateMap<UserDTO, User>();
            CreateMap<CreateUserDTO, User>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(d => d.Id, opt => opt.Ignore());
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<Customer, GetCustomerDTO>();
        }
    }
}
