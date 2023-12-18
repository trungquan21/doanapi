using Microsoft.AspNetCore.Identity;
using doanapi.Models;
using doanapi.Models.Authenticate;

namespace doanapi.Service
{
    public interface IAuthService
    {
        public Task<bool> RegisterAsync(UserModel model);
        public Task<string> LoginAsync(LoginViewModel model);
        public Task<bool> LogoutAsync(HttpContext context);
        public Task<bool> AssignRoleAsync(AssignRoleModel model);
        public Task<bool> RemoveRoleAsync(AssignRoleModel model);
        public Task<bool> UpdatePasswordAsync(UserModel model, string currentPassword, string newPassword);
        public Task<bool> SetPasswordAsync(UserModel model, string newPassword);

    }
}
