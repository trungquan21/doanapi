using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;
using doanapi.Models;

namespace doanapi.Service
{
    public class UserDashboardService
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public UserDashboardService(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserDashboardModel>> GetAllUserDashboardAsync()
        {
            var items = await _context.UserDashboards!.Where(x => x.Id > 0).ToListAsync();
            return _mapper.Map<List<UserDashboardModel>>(items);
        }

        public async Task<UserDashboardModel> GetUserDashboardByIdAsync(int Id)
        {
            var item = await _context!.UserDashboards!.FindAsync(Id);
            return _mapper.Map<UserDashboardModel>(item);
        }

        public async Task<bool> SaveUserDashboardAsync(UserDashboardModel model)
        {
            var exitsItem = await _context!.UserDashboards!.FindAsync(model.Id);

            if (exitsItem == null || model.Id == 0)
            {
                var newItem = _mapper.Map<UserDashboards>(model);

                _context.UserDashboards!.Add(newItem);
            }
            else
            {
                var updateItem = await _context.UserDashboards!.FirstOrDefaultAsync(d => d.Id == model.Id);

                updateItem = _mapper.Map(model, updateItem);
                _context.UserDashboards!.Update(updateItem!);
            }

            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteUserDashboardAsync(UserDashboardModel model)
        {
            var exitsItem = await _context!.UserDashboards!.FindAsync(model.Id);

            if (exitsItem == null) { return false; }

            _context.UserDashboards.Remove(exitsItem);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
