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
                .ForMember(ent => ent.Id, opt => opt.Ignore());

            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.Roles, opt => opt.MapFrom(usr => usr.UserRoles.Select(u_r => u_r.Role!.Name)));
            CreateMap<UserDTO, User>();
            CreateMap<CreateUserDTO, User>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());
            CreateMap<CreateCustomerDTO, Customer>();
            CreateMap<Customer, GetCustomerDTO>();

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>()
                .ForMember(ent => ent.Id, opt => opt.Ignore())
                .ForMember(ent => ent.Guid, opt => opt.Ignore());

            CreateMap<Admin, AdminDTO>();
            CreateMap<AdminDTO, Admin>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());
        }
    }
}
