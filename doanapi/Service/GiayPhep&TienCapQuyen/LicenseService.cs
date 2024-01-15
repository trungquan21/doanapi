using AutoMapper;
using AutoMapper.QueryableExtensions;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;

namespace doanapi.Service
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
        public async Task<List<LicenseDto>> GetAllAsync(string LicenseNumber, int LicenseTypeId, string LicensingAuthorities, string Validityoflicense )
        {
            var query = _context.License!
                .Where(gp => gp.Deleted == false)
                .Include(gp => gp.LicenseType)
                .Include(gp => gp.Construction)
                .Include(gp => gp.LicenseFee)
                .OrderBy(x => x.SignDay)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            //if (await _userManager.IsInRoleAsync(currentUser!, "Construction"))
            //{
            //    query = query.Where(x => x.Construction!.!.ToLower() == currentUser!.UserName!.ToLower());
            //}

            if (!string.IsNullOrEmpty(LicenseNumber))
            {
                query = query.Where(x => x.LicenseNumber!.Contains(LicenseNumber));
            }

            if (!string.IsNullOrEmpty(LicensingAuthorities))
            {
                query = query.Where(x => x.LicensingAuthorities!.Contains(LicensingAuthorities));
            }

            if (LicenseTypeId > 0)
            {
                query = query.Where(x => x.LicenseTypeId == LicenseTypeId);
            }

      
            if (!string.IsNullOrEmpty(Validityoflicense))
            {
                switch (Validityoflicense.ToLower())
                {
                    case "sap-het-hieu-luc":
                        query = query
                            .Where(x => x.ExpirationDate.HasValue &&
                                        x.ExpirationDate >= DateTime.Today &&
                                        x.ExpirationDate < DateTime.Today.AddDays(160) &&
                                        x.Revoked == false);
                        break;
                    case "het-hieu-luc":
                        query = query
                            .Where(x => x.ExpirationDate.HasValue &&
                                        x.ExpirationDate < DateTime.Today &&
                                        x.Revoked == false);
                        break;
                    case "con-hieu-luc":
                        query = query
                            .Where(x => x.ExpirationDate.HasValue &&
                                        x.ExpirationDate > DateTime.Today.AddDays(160) &&
                                        x.Revoked == false);
                        break;
                    case "da-bi-thu-hoi":
                        query = query.Where(x => x.Revoked == true);
                        break;
                    default: break;
                }
            }

            var giayphep = await query.ProjectTo<LicenseDto>(_mapper.ConfigurationProvider).ToListAsync();

            return giayphep;
            //var giayphep = await query.ToListAsync();

            //var giayPhepDtos = _mapper.Map<List<LicenseDto>>(giayphep);

            //foreach (var dto in giayPhepDtos)
            //{
            //    var gp_cu = await _context.License!.Where(gp => gp.Id == dto.IdOld && gp.Deleted == false).ToListAsync();
            //    if (gp_cu != null)
            //    {
            //        dto.LicenseOld = _mapper.Map<List<LicenseDto>>(gp_cu);
            //    }

            //    // Assuming this code is within an async method
            //    var tcqIds = dto.gp_tcq!.Select(x => x.IdTCQ).ToList();

            //    var tcqThongTinList = await _context.TCQ_ThongTin!
            //        .Where(x => tcqIds.Contains(x.Id) && x.DaXoa == false)
            //        .ToListAsync();

            //    dto.tiencq = _mapper.Map<List<TCQ_ThongTinDto>>(tcqThongTinList);

            //    dto.gp_tcq = null;
            //}

            //return giayPhepDtos;
        }

        //method count
        public async Task<CountFolowLicensingAuthoritiesDto> CountFolowLicensingAuthoritiesAsync()
        {
            // Count total, Btnmt, and Ubndt entities
            var totalCount = await _context.License!
                .Where(gp => gp.Deleted == false)
                .CountAsync();

            var btnmtCount = await _context.License!
                .Where(gp => gp.Deleted == false && gp.LicensingAuthorities!.ToLower() == "btnmt")
                .CountAsync();

            var ubndtCount = await _context.License!
                .Where(gp => gp.Deleted == false && gp.LicensingAuthorities!.ToLower() == "ubndt")
                .CountAsync();

            return new CountFolowLicensingAuthoritiesDto
            {
                Total = totalCount,
                Btnmt = btnmtCount,
                Ubndt = ubndtCount
            };
        }
        //count theo tung loai cong trinh
        // Method to count the number of GP_ThongTin entities based on construction types
        public async Task<CountFolowConstructionTypesDto> CountFolowConstructionTypesAsync()
        {
            var today = DateTime.Today;

            var query = _context.License!
                .Where(gp => gp.Deleted == false)
                .Include(gp => gp.Construction).ThenInclude(ct => ct!.ConstructionType)
                .AsQueryable();

            // Count entities for different construction types
            var ktsd_nm = query.Where(gp => gp.Construction!.ConstructionType!.IdParent == 1);
            var ktsd_ndd = query.Where(gp => gp.Construction!.ConstructionType!.Id == 7);
            var thamdo_ndd = query.Where(gp => gp.Construction!.ConstructionType!.Id == 8);
            var xathai = query.Where(gp => gp.Construction!.ConstructionType!.IdParent == 3);

            return new CountFolowConstructionTypesDto
            {
                Ktsd_nm = new CountFolowConsTypesData
                {
                    Total = await ktsd_nm.CountAsync(),
                    Con_hieuluc = await ktsd_nm.CountAsync(gp => gp.Revoked == false && gp.ExpirationDate >= today),
                    Bo_cap = await ktsd_nm.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "btnmt"),
                    Tinh_cap = await ktsd_nm.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "ubndt"),
                },
                Ktsd_ndd = new CountFolowConsTypesData
                {
                    Total = await ktsd_ndd.CountAsync(),
                    Con_hieuluc = await ktsd_ndd.CountAsync(gp => gp.Revoked == false && gp.ExpirationDate >= today),
                    Bo_cap = await ktsd_ndd.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "btnmt"),
                    Tinh_cap = await ktsd_ndd.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "ubndt"),
                },
                Thamdo_ndd = new CountFolowConsTypesData
                {
                    Total = await thamdo_ndd.CountAsync(),
                    Con_hieuluc = await thamdo_ndd.CountAsync(gp => gp.Revoked == false && gp.ExpirationDate >= today),
                    Bo_cap = await thamdo_ndd.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "btnmt"),
                    Tinh_cap = await thamdo_ndd.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "ubndt"),
                },
               
                Xathai = new CountFolowConsTypesData
                {
                    Total = await xathai.CountAsync(),
                    Con_hieuluc = await xathai.CountAsync(gp => gp.Revoked == false && gp.ExpirationDate >= today),
                    Bo_cap = await xathai.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "btnmt"),
                    Tinh_cap = await xathai.CountAsync(gp => gp.LicensingAuthorities!.ToLower() == "ubndt"),
                },
            };
        }

        // Method to get GP_ThongTin entity by Id
        public async Task<LicenseDto> GetByIdAsync(int Id)
        {
            // Query to get GP_ThongTin entity by Id
            var query = _context.License!
                .Where(gp => gp.Id == Id && gp.Deleted == false)
                .Include(gp => gp.LicenseType)
                .Include(gp => gp.Organization)
                //.Include(gp => gp.GP_TCQ)
                .OrderBy(x => x.SignDay)
                .AsQueryable();

            var giayphep = await query.FirstOrDefaultAsync();

            var giayPhepDto = _mapper.Map<LicenseDto>(giayphep);
            // Assuming this code is within an async method
            //var tcqIds = giayPhepDto.gp_tcq!.Select(x => x.IdTCQ).ToList();

            //var tcqThongTinList = await _context.TCQ_ThongTin!
            //    .Where(x => tcqIds.Contains(x.Id) && x.DaXoa == false)
            //    .ToListAsync();

            //giayPhepDto.tiencq = _mapper.Map<List<TCQ_ThongTinDto>>(tcqThongTinList);

            //giayPhepDto.gp_tcq = null;

            return giayPhepDto;
        }

        // Method to get license statistics based on filter criteria
        public async Task<LicenseStatisticsDto> LicenseStatisticsAsync(int? tu_nam, int? den_nam)
        {
            var query = _context.License!
               .Where(gp => gp.Deleted == false && gp.SignDay != null)
               .Include(gp => gp.Construction).ThenInclude(ct => ct!.ConstructionType)
               .AsQueryable();
            if (tu_nam > 0)
            {
                query = query.Where(x => x.SignDay!.Value.Year >= tu_nam);
            }

            if (den_nam > 0)
            {
                query = query.Where(x => x.SignDay!.Value.Year <= den_nam);
            }
            var categoryQueries = new List<(string, Func<IQueryable<License>, IQueryable<License>>)>
{
                ("Khai thác sử dụng nước mặt", q => q.Where(gp => gp.Construction!.ConstructionType!.IdParent == 1)),
                ("Khai thác sử dụng nước dưới đất", q => q.Where(gp => gp.Construction!.ConstructionType!.Id == 7)),
                ("Thăm dò nước dưới đất", q => q.Where(gp => gp.Construction!.ConstructionType!.Id == 8)),
                ("Hành nghề khoan", q => q.Where(gp => gp.Construction!.ConstructionType!.Id == 9)),
                ("Xả thải vào nguồn nước", q => q.Where(gp => gp.Construction!.ConstructionType!.IdParent == 3))
            };

            var distinctYears = Enumerable.Range((int)tu_nam!, (int)(den_nam! - tu_nam! + 1)).ToArray();

            var color = new string[]
            {
            "rgb(106, 179, 230)",
            "rgb(0, 61, 126)",
            "rgb(125, 95, 58)",
            "rgb(0, 178, 151)",
            "rgb(244, 153, 23)"
            };

            var seriesList = new List<ApexChartSeriesDto>();

            foreach (var (categoryName, categoryQuery) in categoryQueries)
            {
                var categoryCounts = new int[distinctYears.Length];

                for (int j = 0; j < distinctYears.Length; j++)
                {
                    categoryCounts[j] = await categoryQuery(query)
                        .CountAsync(gp => gp.SignDay!.Value.Year == distinctYears[j]);
                }

                seriesList.Add(new ApexChartSeriesDto
                {
                    Name = categoryName,
                    Data = categoryCounts.ToList() // Convert the array to a list
                });
            }

            return new LicenseStatisticsDto
            {
                Color = color,
                Year = distinctYears,
                Series = seriesList
            };
        }
        // Method to save or update a GP_ThongTin entity
        public async Task<int> SaveAsync(LicenseDto model)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            License item = null; // Declare item variable

            var existingItem = await _context.License!.FirstOrDefaultAsync(d => d.Id == model.Id && d.Deleted == false);

            if (existingItem == null || model.Id == 0)
            {
                item = _mapper.Map<License>(model);
                item.Deleted = false;
                item.CreationTime = DateTime.Now;
                item.AccountCreated = currentUser != null ? currentUser.UserName : null;

                _context.License!.Add(item);
            }
            else
            {
                item = existingItem; // Assign existingItem to item

                _mapper.Map(model, item); // Map properties from model to item
                item.Deleted = false;
                item.RepairTime = DateTime.Now;
                item.EditAccount = currentUser != null ? currentUser.UserName : null;
                _context.License!.Update(item);
            }

            var res = await _context.SaveChangesAsync();

            // Simplified assignment of id
            id = (int)(res > 0 ? item.Id : 0);

            return id;
        }

        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.License!.FirstOrDefaultAsync(d => d.Id == Id && d.Deleted == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; }
            existingItem.RepairTime = DateTime.Now;
            existingItem.EditAccount = currentUser != null ? currentUser.UserName : null;
            existingItem!.Deleted = true;
            _context.License!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
