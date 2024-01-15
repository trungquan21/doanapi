using AutoMapper;
using doanapi.Data;
using doanapi.Dto;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace doanapi.Service
{
    public class ToChucCaNhanService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public ToChucCaNhanService(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _context = context;
            _mapper = mapper;
            _httpContext = httpContext;
        }

        public async Task<List<OrganizationDto>> GetAllAsync()
        {
            var items = await _context.Organization!.Where(x => x.Deleted == false).OrderBy(x => x.OrganizationName).ToListAsync();
            return _mapper.Map<List<OrganizationDto>>(items);
        }

        public async Task<OrganizationDto> GetByIdAsync(int Id)
        {
            var item = await _context.Organization!.FindAsync(Id);
            return _mapper.Map<OrganizationDto>(item);
        }

        public async Task<bool> SaveAsync(OrganizationDto model)
        {
            var existingItem = await _context.Organization!.FirstOrDefaultAsync(d => d.Id == model.Id && d.Deleted == false);

            if (existingItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<Organization>(model);
                newItem.Deleted = false;
                newItem.CreationTime = DateTime.Now;
                newItem.AccountCreated = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.Organization!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.Organization!.FirstOrDefaultAsync(d => d.Id == model.Id && d.Deleted == false);

                updateItem = _mapper.Map(model, updateItem);

                updateItem!.RepairTime = DateTime.Now;
                updateItem.EditAccount = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? "";
                _context.Organization!.Update(updateItem);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(int Id)
        {
            var existingItem = await _context.Organization!.FirstOrDefaultAsync(d => d.Id == Id && d.Deleted == false);

            if (existingItem == null) { return false; }

            existingItem!.Deleted = true;
            _context.Organization!.Update(existingItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
