using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace doanapi.Service
{
    public class DonViHCService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        public DonViHCService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        public async Task<List<DonViHCDto>> GetAllAsync()
        {
            var items = await _context!.DonViHC!
                .Where(x => x.Deleted == false)
                .OrderBy(x => x.DistrictName)
                .ToListAsync();

            var listItems = _mapper.Map<List<DonViHCDto>>(items);
            return listItems;
        }

        public async Task<List<HuyenDto>> GetAllDistrictAsync()
        {
            var items = await _context.DonViHC!
                .Where(l => l.ProvinceId== 51 && l.Deleted == false)
                .GroupBy(l => new { l.ProvinceId, l.DistrictId })
                .Select(group => group.First())
                .ToListAsync();

            var listItems = _mapper.Map<List<HuyenDto>>(items);
            return listItems;
        }

        public async Task<List<XaDto>> GetAllCommuneAsync()
        {
            var items = await _context.DonViHC!
                .Where(l => l.CommuneId != null && l.Deleted == false)
                .GroupBy(l => new { l.DistrictId, l.CommuneId })
                .Select(group => group.First())
                .ToListAsync();

            var listItems = _mapper.Map<List<XaDto>>(items);
            return listItems;
        }

        public async Task<List<XaDto>> GetAllCommuneByDistrictAsync(int DistrictId)
        {
            var items = await _context.DonViHC!
                .Where(l => l.DistrictId == DistrictId && l.Deleted == false)
                .GroupBy(l => new { l.DistrictId, l.CommuneId })
                .Select(group => group.First())
                .ToListAsync();

            var listItems = _mapper.Map<List<XaDto>>(items);
            return listItems;
        }

        public async Task<DonViHCDto?> GetByIdAsync(int Id)
        {
            var item = await _context.DonViHC!.FindAsync(Id);
            return _mapper.Map<DonViHCDto>(item);
        }


        public async Task<bool> SaveAsync(DonViHCDto model)
        {
            var existingItem = await _context.DonViHC!.FirstOrDefaultAsync(d => d.Id == model.Id && d.Deleted == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<DonViHC>(model);
                newItem.Deleted = false;
                newItem.CreationTime = DateTime.Now;
                newItem.AccountCreated = currentUser != null ? currentUser.UserName : null;
                _context.DonViHC!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.DonViHC!.FirstOrDefaultAsync(d => d.Id == model.Id && d.Deleted == false);

                updateItem = _mapper.Map(model, updateItem);
                updateItem!.Deleted = false;
                updateItem.RepairTime = DateTime.Now;
                updateItem.EditAccount = currentUser != null ? currentUser.UserName : null;
                _context.DonViHC!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.DonViHC!.FirstOrDefaultAsync(d => d.Id == Id && d.Deleted == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem!.Deleted = true; // Mark the item as deleted
            existingItem.RepairTime = DateTime.Now;
            existingItem.EditAccount = currentUser != null ? currentUser.UserName : null;
            _context.DonViHC!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
