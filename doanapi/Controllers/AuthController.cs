using doanapi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace doanapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<string> Login(string email,string password)
        {
            return await authService.LoginAsync(new Models.Authenticate.LoginViewModel { UserName=email, Password = password });
        } 
    }
}
