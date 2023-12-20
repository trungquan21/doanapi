using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using doanapi.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;
using doanapi.Models.Authenticate;
using doanapi.Models;
using System.Linq;

namespace doanapi.Service
{
    public class AuthService : IAuthService
    {
        private readonly Data.DatabaseContext _context;
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly RoleManager<AspNetRoles> _roleManager;

        public SignInManager<AspNetUsers> _signInManager { get; }

        private readonly IConfiguration _configuration;

        public AuthService(UserManager<AspNetUsers> userManager, SignInManager<AspNetUsers> signInManager, RoleManager<AspNetRoles> roleManager, IConfiguration configuration, Data.DatabaseContext context)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<bool> RegisterAsync(UserModel model)
        {
            // Create a new user
            AspNetUsers user = new AspNetUsers
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
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

        public async Task<string> LoginAsync(LoginViewModel model)
        {
            var res = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            if (!res.Succeeded)
            {
                return string.Empty;
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            var roles = await _userManager.GetRolesAsync(user!);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user!.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? ""),
                new Claim(ClaimTypes.NameIdentifier, user.FullName ?? ""),
                
            };
            claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? ""));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandle = new JwtSecurityTokenHandler();

            var token = tokenHandle.CreateToken(tokenDescriptor);

            return tokenHandle.WriteToken(token);
        }


        public async Task<bool> UpdatePasswordAsync(UserModel model, string currentPassword, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(model.UserName!);
            var res = await _userManager.ChangePasswordAsync(user!, currentPassword, newPassword);
            if (res.Succeeded) { return true; }
            return false;
        }

        public async Task<bool> SetPasswordAsync(UserModel model, string newPassword)
        {
            var user = await _userManager.FindByNameAsync(model.UserName!);

            if (user != null)
            {
                var removePasswordResult = await _userManager.RemovePasswordAsync(user);
                if (removePasswordResult.Succeeded)
                {
                    var addPasswordResult = await _userManager.AddPasswordAsync(user, newPassword);
                    return addPasswordResult.Succeeded;
                }
            }

            return false;
        }


        public async Task<bool> AssignRoleAsync(AssignRoleModel model)
        {
            var user = await _userManager.FindByIdAsync(model.userId);
            if (user == null) { return false; }

            // Remove all existing roles of the user
            var existingRoles = await _userManager.GetRolesAsync(user);
            if (existingRoles == null) { return false; }

            await _userManager.RemoveFromRolesAsync(user!, existingRoles);

            // Add the new role to the user
            await _userManager.AddToRoleAsync(user!, model.roleName);

            return true;
        }

        public async Task<bool> RemoveRoleAsync(AssignRoleModel model)
        {
            var u = await _userManager.FindByIdAsync(model.userId);
            // Check if the user is already in the role
            var isInRole = await _userManager.IsInRoleAsync(u!, model.roleName);
            if (isInRole)
            {
                await _userManager.RemoveFromRoleAsync(u!, model.roleName);
                var role = await _roleManager.Roles.FirstOrDefaultAsync(u => u.IsDefault == true);
                await _userManager.AddToRoleAsync(u!, role!.Name!);

                return true;
            }
            return false;
        }


        public async Task<bool> LogoutAsync(HttpContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return true;
        }

    }
}
