using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace doanapi.Service.GiayPhep_TienCapQuyen
{
    public class LicenseTypeService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public LicenseTypeService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to retrieve all GP_Loai entities
        public async Task<List<LicenseTypeDto>> GetAllAsync()
        {
            // Retrieve non-deleted items and order them by TenLoaiGP
            var items = await _context.LicenseType!.Where(x => x.Deleted == false).OrderBy(x => x.LicenseTypeName).ToListAsync();

            // Map the entities to DTOs and return the result
            return _mapper.Map<List<LicenseTypeDto>>(items);
        }

        // Method to retrieve a specific GP_Loai entity by Id
        public async Task<LicenseTypeDto> GetLicenseTypeByIdAsync(int Id)
        {
            // Find the GP_Loai entity by Id
            var item = await _context.LicenseType!.FindAsync(Id);

            // Map the entity to a DTO and return the result
            return _mapper.Map<LicenseTypeDto>(item);
        }

        // Method to save or update a GP_Loai entity
        public async Task<bool> SaveAsync(LicenseTypeDto dto)
        {
            var existingItem = await _context.LicenseType!.FirstOrDefaultAsync(d => d.Id == dto.Id);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);
            LicenseType item = null;
            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                item = _mapper.Map<LicenseType>(dto);
                item.Deleted = false;
                item.AccountCreated = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                _context.LicenseType!.Add(item);
            }
            else
            {
                // If the item exists, update it with values from the dto
                item = existingItem;
                item = _mapper.Map(dto, item);
                item.Deleted = false;
                item.AccountCreated = currentUser != null ? currentUser.UserName : null;
                _context.LicenseType!.Update(item);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful save or update
            return true;
        }

        // Method to delete a GP_Loai entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.LicenseType!.FirstOrDefaultAsync(d => d.Id == Id);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem.RepairTime = DateTime.Now;
            existingItem.EditAccount = currentUser != null ? currentUser.UserName : null;
            existingItem!.Deleted = true; // Mark the item as deleted
            _context.LicenseType!.Update(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
