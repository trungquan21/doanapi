using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace doanapi.Service
{
    public class LicenseFeeService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public LicenseFeeService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to get all TCQ_ThongTin entities
        public async Task<List<LicenseFeeDto>> GetAllAsync(string DecisionNumber, string LicensingAuthorities)
        {
            var query = _context.LicenseFee!
                .Where(gp => gp.Deleted == false)
                .AsQueryable();

            // Apply filters based on input parameters
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            if (!string.IsNullOrEmpty(DecisionNumber))
            {
                query = query.Where(x => x.DecisionNumber!.Contains(DecisionNumber));
            }

            if (!string.IsNullOrEmpty(LicensingAuthorities))
            {
                query = query.Where(x => x.LicensingAuthorities!.Contains(LicensingAuthorities));
            }

            var listItems = _mapper.Map<List<LicenseFeeDto>>(query);

            return listItems;
        }

        // Method to get TCQ_ThongTin entities by licensing authorities
        public async Task<List<LicenseFeeDto>> GetByLicensingAuthoritiesAsync(string coquan_cp)
        {
            var query = _context!.LicenseFee!
                .Where(u => u.Deleted == false)
                .OrderBy(x => x.SignDay)
                .AsQueryable();

            if (coquan_cp == "bo-cap")
            {
                query = query.Where(u => u.LicensingAuthorities == "BTNMT");
            }
            else if (coquan_cp == "tinh-cap")
            {
                query = query.Where(u => u.LicensingAuthorities == "UBNDT");
            }

            var items = await query.ToListAsync();

            var listItems = _mapper.Map<List<LicenseFeeDto>>(items);

            foreach (var dto in listItems)
            {
                // Assuming this code is within an async method

                //var gpList = await _context.License!
                //    .Where(x => x.Id && x.Deleted == false)
                //    .ToListAsync();

                //dto.Licenses = _mapper.Map<List<LicenseFeeDto>>(gpList);

                //dto.gp_tcq = null;

            }

            return listItems;
        }

        // Method to get TCQ_ThongTin entity by Id
        public async Task<LicenseFeeDto> GetByIdAsync(int Id)
        {
            var item = await _context.LicenseFee!.FindAsync(Id);
            return _mapper.Map<LicenseFeeDto>(item);
        }

        // Method to save or update a TCQ_ThongTin entity
        public async Task<int> SaveAsync(LicenseFeeDto dto)
        {
            int id = 0;
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            LicenseFee item = null; // Declare item variable

            // Retrieve an existing item based on Id or if dto.Id is 0
            var existingItem = await _context.LicenseFee!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.Deleted == false);

            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                item = _mapper.Map<LicenseFee>(dto);
                item.Deleted = false;
                item.CreationTime = DateTime.Now;
                item.AccountCreated = currentUser != null ? currentUser.UserName : null;
                _context.LicenseFee!.Add(item);
            }
            else
            {
                // If the item exists, update it with values from the dto
                item = existingItem;
                _mapper.Map(dto, item);
                item.Deleted = false;
                item.RepairTime = DateTime.Now;
                item.EditAccount = currentUser != null ? currentUser.UserName : null;
                _context.LicenseFee!.Update(item);
            }

            // Save changes to the database
            var res = await _context.SaveChangesAsync();

            // Simplified assignment of id based on the result of SaveChanges
            id = (int)(res > 0 ? item.Id : 0);

            // Return the id
            return id;
        }

        // Method to delete a TCQ_ThongTin entity
        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.LicenseFee!.FirstOrDefaultAsync(d => d.Id == Id && d.Deleted == false);

            if (existingItem == null) { return false; }

            existingItem!.Deleted = true;
            _context.LicenseFee!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
