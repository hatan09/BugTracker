using AutoMapper;
using BugTracker.Core.Entities;
using System.Linq;

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

            CreateMap<Admin, AdminDTO>();
            CreateMap<AdminDTO, Admin>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());
            CreateMap<CreateCustomerDTO, Customer>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());
            CreateMap<Customer, GetCustomerDTO>();

            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>()
                .ForMember(ent => ent.Id, opt => opt.Ignore())
                .ForMember(ent => ent.Guid, opt => opt.Ignore());

            CreateMap<App, AppDTO>();
            CreateMap<AppDTO, App>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());
            CreateMap<CreateAppDTO, App>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());

            CreateMap<Report, ReportDTO>();
            CreateMap<ReportDTO, Report>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());

            CreateMap<Bug, BugDTO>();
            CreateMap<BugDTO, Bug>()
                .ForMember(ent => ent.Id, opt => opt.Ignore());
        }
    }
}
