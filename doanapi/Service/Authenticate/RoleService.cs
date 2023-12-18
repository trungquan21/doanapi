using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;
using doanapi.Models;
using System.Data;

namespace doanapi.Service
{
    public class RoleService
    {
        private readonly RoleManager<AspNetRoles> _roleManager;
        private readonly Data.DatabaseContext _context;
        private readonly IMapper _mapper;

        public RoleService(IServiceProvider serviceProvider, Data.DatabaseContext context, IMapper mapper)
        {
            _roleManager = serviceProvider.GetRequiredService<RoleManager<AspNetRoles>>();
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoleModel>> GetAllRolesAsync()
        {
            var items = await _context.Roles
                .Where(u => u.IsDeleted == false)
                .ToListAsync();
            var listItems = _mapper.Map<List<RoleModel>>(items);

            foreach (var item in listItems)
            {
                var dashIds = _context!.RoleDashboards!.Where(x => x.RoleId == item.Id).Select(x => x.DashboardId).ToList();
                var dashboards = await _context!.Dashboards!.Where(x => dashIds.Contains(x.Id)).ToListAsync();
                item.Dashboards = _mapper.Map<List<DashboardModel>>(dashboards);
                foreach (var dash in item.Dashboards)
                {
                    var functions = await _context!.Functions!.Where(x => x.Id > 0).ToListAsync();
                    dash.Functions = _mapper.Map<List<FunctionModel>>(functions);
                    foreach (var function in dash.Functions)
                    {
                        var existingPermission = await _context.Permissions!.
                            FirstOrDefaultAsync(d => d.FunctionId == function.Id && d.DashboardId == dash.Id && d.RoleId == item.Id);

                        if (existingPermission != null)
                        {
                            function.Status = true;
                        }
                        else
                        {
                            function.Status = false;
                        }
                    }
                }
            }

            return listItems;
        }

        public async Task<RoleModel> GetRoleByIdAsync(string roleId)
        {
            var item = await _roleManager.FindByIdAsync(roleId);
            var role = _mapper.Map<RoleModel>(item);
            var dashIds = _context!.RoleDashboards!.Where(x => x.RoleId == roleId).Select(x => x.DashboardId).ToList();
            var dashboards = await _context!.Dashboards!.Where(x => dashIds.Contains(x.Id)).ToListAsync();
            role.Dashboards = _mapper.Map<List<DashboardModel>>(dashboards);
            foreach (var dash in role.Dashboards)
            {
                var functions = await _context!.Functions!.Where(x => x.Id > 0).ToListAsync();
                dash.Functions = _mapper.Map<List<FunctionModel>>(functions);
                foreach (var function in dash.Functions)
                {
                    var existingPermission = await _context.Permissions!.
                        FirstOrDefaultAsync(d => d.FunctionId == function.Id && d.DashboardId == dash.Id && d.RoleId == role.Id);

                    if (existingPermission != null)
                    {
                        function.Status = true;
                    }
                    else
                    {
                        function.Status = false;
                    }
                }
            }

            return role;
        }


        public async Task<bool> SaveRoleAsync(RoleModel model)
        {
            var exitsRole = await _roleManager.FindByIdAsync(model.Id);

            if (exitsRole == null)
            {
                // Create a new user
                AspNetRoles item = new AspNetRoles();
                if (model.Name == item.Name) { return false; }
                item.Name = model.Name;
                item.IsDefault = model.IsDefault;
                item.IsDeleted = false;

                await _roleManager.CreateAsync(item);
                return true;
            }
            else
            {
                exitsRole.Name = model.Name;
                exitsRole.IsDefault = model.IsDefault;
                exitsRole.IsDeleted = false;
                await _roleManager.UpdateAsync(exitsRole);
                return true;
            }
        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            var item = await _roleManager.FindByIdAsync(roleId);

            if (item == null) { return false; }

            // Update role properties based on the RegisterViewModel
            item.IsDeleted = true;
            await _roleManager.UpdateAsync(item);
            return true;
        }
    }
}
