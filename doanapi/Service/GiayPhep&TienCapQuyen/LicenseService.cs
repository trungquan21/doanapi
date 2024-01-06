using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace doanapi.Service.GiayPhep_TienCapQuyen
{
    public class LicenseService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;
        public LicenseService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }
    //    public async Task<List<LicenseDto>> GetAllAsync(string LicenseNumber,int LicenseTypeId,int OrganizationName)
    //    {
    //        var query = _context.License!
    //            .Where(gp => gp.Deleted == false)
    //            .Include(gp => gp.LicenseType)
    //            .Include(gp => gp.Organization)
    //            .Include(gp => gp.Construction)
    //            .Include(gp => gp.Construction).ThenInclude(ct => ct!.ConstructionType)
    //            //.Include(gp => gp.GP_TCQ)
    //            .OrderBy(x => x.SignDay)
    //            .AsQueryable();
            
    //        // Apply filters based on input parameters
    //        var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

    //        //if (await _userManager.IsInRoleAsync(currentUser!, "Construction"))
    //        //{
    //        //    query = query.Where(x => x.Construction!.!.ToLower() == currentUser!.UserName!.ToLower());
    //        //}

    //        if (!string.IsNullOrEmpty(LicenseNumber))
    //        {
    //            query = query.Where(x => x.LicenseNumber!.Contains(LicenseNumber));
    //        }

    //        if (!string.IsNullOrEmpty(Organization))
    //        {
    //            query = query.Where(x => x.CoQuanCapPhep!.Contains(filterDto.coquan_cp));
    //        }

    //        if (filterDto.tochuc_canhan > 0)
    //        {
    //            query = query.Where(x => x.IdTCCN == filterDto.tochuc_canhan);
    //        }

    //        if (filterDto.cong_trinh > 0)
    //        {
    //            query = query.Where(x => x.IdCT == filterDto.cong_trinh);
    //        }

    //        if (filterDto.loaihinh_cp > 0)
    //        {
    //            query = query.Where(x => x.IdLoaiGP == filterDto.loaihinh_cp);
    //        }

    //        if (filterDto.loai_ct > 0)
    //        {
    //            query = query.Where(gp => filterDto.loai_ct == 1 || filterDto.loai_ct == 2 || filterDto.loai_ct == 3 || filterDto.loai_ct == 24 ? gp.CongTrinh!.LoaiCT!.IdCha == filterDto.loai_ct : gp.CongTrinh!.LoaiCT!.Id == filterDto.loai_ct);
    //        }

    //        if (!string.IsNullOrEmpty(filterDto.hieuluc_gp))
    //        {
    //            switch (filterDto.hieuluc_gp.ToLower())
    //            {
    //                case "sap-het-hieu-luc":
    //                    query = query
    //                        .Where(x => x.NgayHetHieuLuc.HasValue &&
    //                                    x.NgayHetHieuLuc >= DateTime.Today &&
    //                                    x.NgayHetHieuLuc < DateTime.Today.AddDays(160) &&
    //                                    x.DaBiThuHoi == false);
    //                    break;
    //                case "het-hieu-luc":
    //                    query = query
    //                        .Where(x => x.NgayHetHieuLuc.HasValue &&
    //                                    x.NgayHetHieuLuc < DateTime.Today &&
    //                                    x.DaBiThuHoi == false);
    //                    break;
    //                case "con-hieu-luc":
    //                    query = query
    //                        .Where(x => x.NgayHetHieuLuc.HasValue &&
    //                                    x.NgayHetHieuLuc > DateTime.Today.AddDays(160) &&
    //                                    x.DaBiThuHoi == false);
    //                    break;
    //                case "da-bi-thu-hoi":
    //                    query = query.Where(x => x.DaBiThuHoi == true);
    //                    break;
    //                default: break;
    //            }
    //        }

    //        var giayphep = await query.ToListAsync();

    //        var giayPhepDtos = _mapper.Map<List<LicenseDto>>(giayphep);

    //        foreach (var dto in giayPhepDtos)
    //        {
    //            if (dto.congtrinh != null)
    //            {
    //                dto.congtrinh!.giayphep = null;
    //                dto.congtrinh.hangmuc = dto.congtrinh.hangmuc != null ? _mapper.Map<List<CT_HangMucDto>>(dto.congtrinh.hangmuc!.Where(x => x.DaXoa == false)) : null;
    //                dto.congtrinh.luuluongtheo_mucdich = dto.congtrinh.luuluongtheo_mucdich != null ? _mapper.Map<List<LuuLuongTheoMucDichDto>>(dto.congtrinh.luuluongtheo_mucdich!.Where(x => x.DaXoa == false)) : null;
    //                dto.congtrinh!.donvi_hanhchinh = _mapper.Map<DonViHCDto>(_context.DonViHC!.FirstOrDefault(x => x.IdXa!.Contains(dto.congtrinh.IdXa!)));
    //            }

    //            var gp_cu = await _context.License!.Where(gp => gp.Id == dto.IdCon && gp.DaXoa == false).ToListAsync();
    //            if (gp_cu != null)
    //            {
    //                dto.giayphep_cu = _mapper.Map<List<LicenseDto>>(gp_cu);
    //            }

    //            // Assuming this code is within an async method
    //            var tcqIds = dto.gp_tcq!.Select(x => x.IdTCQ).ToList();

    //            var tcqThongTinList = await _context.TCQ_ThongTin!
    //                .Where(x => tcqIds.Contains(x.Id) && x.DaXoa == false)
    //                .ToListAsync();

    //            dto.tiencq = _mapper.Map<List<TCQ_ThongTinDto>>(tcqThongTinList);

    //            dto.gp_tcq = null;
    //        }

    //        return giayPhepDtos;
    //    }


    }
}
