using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace doanapi.Service
{
    public class ConstructionDetailsService
    {

        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AspNetUsers> _userManager;

        // Constructor to initialize the service with required dependencies
        public ConstructionDetailsService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext, UserManager<AspNetUsers> userManager)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
            _userManager = userManager;
        }

        // Method to save or update a CT_ThongSo entity
        public async Task<bool> SaveAsync(ConstructionDetailsDto dto)
        {
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            var existingItem = await _context.ConstructionDetails!
                    .FirstOrDefaultAsync(d => d.Id == dto.Id);

            if (existingItem == null || dto.Id == 0)
            {
                // Create a new item if it doesn't exist or dto.Id is 0
                var newItem = _mapper.Map<ConstructionDetail>(dto);
                // Set nullable properties to null if their values are 0
                if (dto.IdConstruction == 0)
                {
                    newItem.IdConstruction = null;
                }

                newItem.Deleted = false;
                newItem.CreationTime = DateTime.Now;
                newItem.AccountCreated = currentUser != null ? currentUser.UserName : null;
                _context.ConstructionDetails!.Add(newItem);
            }
            else
            {
                // Update the existing item with values from the dto
                var updateItem = _mapper.Map(dto, existingItem);

                // Set nullable properties to null if their values are 0
                if (dto.IdConstruction == 0)
                {
                    updateItem.IdConstruction = null;
                }

                updateItem.Deleted = false;
                updateItem!.RepairTime = DateTime.Now;
                updateItem.EditAccount = currentUser != null ? currentUser.UserName : null;
                _context.ConstructionDetails!.Update(updateItem);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();
            return true;
        }

        // Method to delete a CT_ThongSo entity
        public async Task<bool> DeleteAsync(int Id)
        {
            // Retrieve an existing item based on Id
            var existingItem = await _context.ConstructionDetails!.FirstOrDefaultAsync(d => d.Id == Id && d.Deleted == false);
            var currentUser = await _userManager.GetUserAsync(_httpContext.HttpContext!.User);

            if (existingItem == null) { return false; } // If the item doesn't exist, return false

            existingItem!.Deleted = true; // Mark the item as deleted
            existingItem.RepairTime = DateTime.Now;
            existingItem.EditAccount = currentUser != null ? currentUser.UserName : null;
            _context.ConstructionDetails!.Update(existingItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return true to indicate successful deletion
            return true;
        }
    }
}
