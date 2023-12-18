using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;
using doanapi.Models;

namespace doanapi.Service
{
    public class RoleDashboardService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public RoleDashboardService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoleDashboardModel>> GetAllRoleDashboardAsync()
        {
            var items = await _context.RoleDashboards!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<RoleDashboardModel>>(items);
        }

        public async Task<RoleDashboardModel> GetRoleDashboardByIdAsync(int Id)
        {
            var item = await _context!.RoleDashboards!.FindAsync(Id);
            return _mapper.Map<RoleDashboardModel>(item);
        }

        public async Task<bool> SaveRoleDashboardAsync(RoleDashboardModel model)
        {
            var exitsItem = await _context!.RoleDashboards!.FindAsync(model.Id);

            if (exitsItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<RoleDashboards>(model);

                _context.RoleDashboards!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.RoleDashboards!.FirstOrDefaultAsync(d => d.Id == model.Id);

                updateItem = _mapper.Map(model, updateItem);
                _context.RoleDashboards!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteRoleDashboardAsync(RoleDashboardModel model)
        {
            var exitsItem = await _context!.RoleDashboards!.FindAsync(model.Id);

            if (exitsItem == null) { return false; }

            _context.RoleDashboards.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
