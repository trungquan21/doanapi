using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using doanapi.Models;
using doanapi.Models.Authenticate;

namespace doanapi.Helpers
{
    public class MapperConfigure : Profile
    {
        public MapperConfigure()
        {

            //-------------Authenticatiion--------------------

            //Users
            CreateMap<AspNetUsers, UserModel>().ReverseMap();

            //Users Info
            CreateMap<AspNetUsers, UserInfoModel>().ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Roles
            CreateMap<AspNetRoles, RoleModel>()
                .ForMember(dest => dest.Dashboards, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Dashboards);
                }).ReverseMap();

            //Dashboards
            CreateMap<Dashboards, DashboardModel>()
                .ForMember(dest => dest.Functions, opt =>
                {
                    opt.MapFrom((src, dest) => dest.Functions);
                }).ReverseMap();

            //Permissions
            CreateMap<Permissions, PermissionModel>().ReverseMap();

            //Dashboard for Roles and Users
            CreateMap<UserDashboards, UserDashboardModel>().ReverseMap();
            CreateMap<RoleDashboards, RoleDashboardModel>().ReverseMap();

            //functions
            CreateMap<Functions, FunctionModel>().ReverseMap();

            //-------------Other mapper--------------------
            CreateMap<ConstructionType, ConstructionTypeDto>().ReverseMap();
            CreateMap<ConstructionDetail, ConstructionDetailsDto>().ReverseMap();
            CreateMap<Construction, ConstructionDto>()
                .ForMember(dest => dest.ConstructionType, opt => opt.MapFrom(src => src.ConstructionType))
                .ForMember(dest => dest.ConstructionDetails, opt => opt.MapFrom(src => src.ConstructionDetails))
                .ForMember(dest => dest.Districts, opt => opt.MapFrom(src => src.District))
                .ForMember(dest => dest.Licenses, opt => opt.MapFrom(src => src.License))
            .ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Commune, CommuneDto>().ReverseMap();
            CreateMap<LicenseType, LicenseTypeDto>().ReverseMap();
            CreateMap<License, LicenseDto>()
                .ForMember(dest => dest.Organization, opt => opt.MapFrom(src => src.Organization))
                .ForMember(dest => dest.LicenseType, opt => opt.MapFrom(src => src.LicenseType))
                //.ForMember(dest => dest.LicenseFee, opt => opt.MapFrom((src, dest) => dest.LicenseFee))
                .ReverseMap();
            CreateMap<LicenseFee, LicenseFeeDto>().ReverseMap();
            CreateMap<Organization, OrganizationDto>().ReverseMap();

        }
    }
}
