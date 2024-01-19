using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using doanapi.Data;
using doanapi.Models;
using doanapi.Models.Authenticate;
using System.Data;
using System.Security.Claims;

namespace doanapi.Service
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly Data.DatabaseContext _context;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly RoleManager<AspNetRoles> _roleManager;
        private readonly IHttpContextAccessor _httpContext;


        public UserService(Data.DatabaseContext context, UserManager<AspNetUsers> userManager, RoleManager<AspNetRoles> roleManager, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContext = httpContext;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            var items = await _context.Users
                .Where(u => u.IsDeleted == false)
                .ToListAsync();

            var users = new List<UserModel>();

            foreach (var u in items)
            {
                var user = new UserModel
                {
                    Id = u.Id,
                    UserName = u.UserName!,
                    FullName = u.FullName!,
                    Email = u.Email!,
                    PhoneNumber = u.PhoneNumber!
                };

                var roles = await _userManager.GetRolesAsync(u);
                if (roles.Count > 0)
                {
                    var role = await _roleManager.FindByNameAsync(roles[0]);
                    if (role != null)
                    {
                        user.Role = role.Name;
                    }
                }

                users.Add(user);
            }

            return users;
        }

        public async Task<UserInfoModel> GetUserInfoByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userInfo = _mapper.Map<UserInfoModel>(user);

            var roles = await _userManager.GetRolesAsync(user!);
            var roleName = roles.FirstOrDefault();
            userInfo.Role = roleName;

            return userInfo;

        }

        public async Task<UserModel> GetUserByIdAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var userModel = _mapper.Map<UserModel>(user);
            return userModel;
        }

        public async Task<bool> SaveUserAsync(UserModel model)
        {
            var existingUser = await _userManager.FindByIdAsync(model.Id);

            if (existingUser == null)
            {
                // Create a new user
                AspNetUsers user = new AspNetUsers
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    CreatedUser = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null,
                    CreatedTime = DateTime.Now,
                    IsDeleted = false
                };

                var res = await _userManager.CreateAsync(user, model.Password);

                var role = await _roleManager.Roles.FirstOrDefaultAsync(u => u.IsDefault == true);

                if (res.Succeeded && role != null)
                {
                    await _userManager.AddToRoleAsync(user, role.Name!);
                    return true;
                }
                return false;
            }
            else
            {
                // Update an existing user
                existingUser.UserName = model.UserName;
                existingUser.Email = model.Email;
                existingUser.FullName = model.FullName;
                existingUser.PhoneNumber = model.PhoneNumber;
                existingUser.IsDeleted = false;
                existingUser.ModifiedTime = DateTime.Now;
                existingUser.ModifiedUser = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                var res = await _userManager.UpdateAsync(existingUser);
                if (res.Succeeded)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<bool> DeleteUserAsync(UserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.Id!);
            if (user != null)
            {
                user.IsDeleted = true;
                user.ModifiedTime = DateTime.Now;
                user.ModifiedUser = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.Name) ?? null;
                await _userManager.UpdateAsync(user);
                return true;
            }
            return false;

        }
    }
}
