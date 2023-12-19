﻿using AutoMapper;
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
            CreateMap<LoaiCongTrinh, ConstructionTypeDto>().ReverseMap();
            CreateMap<ThongSoCongTrinh, ConstructionDetailsDto>().ReverseMap();
            CreateMap<CongTrinh, ConstructionDto>()
                .ForMember(dest => dest.ConstructionId, opt => opt.MapFrom(src => src.ConstructionId))
                .ForMember(dest => dest.ConstructionDetails, opt => opt.MapFrom(src => src.ConstructionDetails))
                .ForMember(dest => dest.DonViHanhChinh, opt => opt.MapFrom((src, dest) => dest.DonViHanhChinh))
                //.ForMember(dest => dest.giayphep, opt => opt.MapFrom(src => src.GiayPhep))
            .ReverseMap();
            CreateMap<DonViHC, DonViHCDto>().ReverseMap();
            CreateMap<DonViHC, HuyenDto>().ReverseMap();
            CreateMap<DonViHC, XaDto>().ReverseMap();

        }
    }
}
