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
            CreateMap<AspNetUsers, UserInfoModel>().ReverseMap();

            //Roles
            CreateMap<AspNetRoles, RoleModel>().ReverseMap();
      
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
                .ForMember(dest => dest.LicenseType, opt => opt.MapFrom(src => src.LicenseType))
                .ForMember(dest => dest.Construction, opt => opt.MapFrom(src => src.Construction))
                .ReverseMap();
            CreateMap<LicenseFee, LicenseFeeDto>().ReverseMap();

        }
    }
}
