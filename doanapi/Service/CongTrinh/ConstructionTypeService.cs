using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;
using doanapi.Dto;

namespace doanapi.Service
{
    public class ConstructionTypeService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public ConstructionTypeService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to retrieve all ConstructionType entities
        public async Task<List<ConstructionTypeDto>> GetAllAsync()
        {
            // Retrieve non-deleted items and order them by Id
            var items = await _context.ConstructionType!.Where(x => x.Deleted == false).OrderBy(x => x.Id).ToListAsync();

            // Map the entities to DTOs and return the result
            return _mapper.Map<List<ConstructionTypeDto>>(items);
        }

        // Method to retrieve a specific ConstructionType entity by Id
        public async Task<ConstructionTypeDto> GetByIdAsync(int Id)
        {
            // Find the ConstructionType entity by Id
            var item = await _context.ConstructionType!.FindAsync(Id);

            // Map the entity to a DTO and return the result
            return _mapper.Map<ConstructionTypeDto>(item);
        }

        // Method to save or update a ConstructionType entity
        public async Task<bool> SaveAsync(ConstructionTypeDto dto)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            // Retrieve an existing item based on Id or if dto.Id is 0
            var existingItem = await _context.ConstructionType!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.Deleted == false);

            if (existingItem == null || dto.Id == 0)
            {
                // If the item doesn't exist or dto.Id is 0, create a new item
                var newItem = _mapper.Map<ConstructionType>(dto);
                newItem.Deleted = false;
                newItem.CreationTime = DateTime.Now;
                newItem.AccountCreated = currentUser != null ? currentUser.UserName : null;
                _context.ConstructionType!.Add(newItem);
            }
            else
            {
                // If the item exists, update it with values from the dto
                var updateItem = await _context.ConstructionType!.FirstOrDefaultAsync(d => d.Id == dto.Id && d.Deleted == false);
                updateItem = _mapper.Map(dto, updateItem);
                updateItem!.Deleted = false;
                updateItem.RepairTime = DateTime.Now;
                updateItem.EditAccount = currentUser != null ? currentUser.UserName : null;
                _context.ConstructionType!.Update(updateItem);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful save or update
            return true;
        }

        // Method to delete a ConstructionType entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.ConstructionType!.FirstOrDefaultAsync(d => d.Id == Id && d.Deleted == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem!.Deleted = true; // Mark the item as deleted
            existingItem.RepairTime = DateTime.Now;
            existingItem.EditAccount = currentUser != null ? currentUser.UserName : null;
            _context.ConstructionType!.Update(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
