using Microsoft.AspNetCore.Identity;

namespace doanapi.Data
{
    public class Seed
    {
        public static async Task SeedData(DatabaseContext databaseContext, UserManager<AspNetUsers> userManager, RoleManager<AspNetRoles> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new AspNetRoles { Name = "admin" });
                await roleManager.CreateAsync(new AspNetRoles { Name = "chuyenvien" });
                await roleManager.CreateAsync(new AspNetRoles { Name = "congtrinh" });
            }
            if (!userManager.Users.Any())
            {
                var admin = new AspNetUsers { UserName = "admin" };
                var chuyenvien = new AspNetUsers { UserName = "cv.quan" };
                var congtrinh = new AspNetUsers { UserName = "ct.thuydien" };
                await userManager.CreateAsync(admin, "password");
                await userManager.CreateAsync(chuyenvien, "password");
                await userManager.CreateAsync(congtrinh, "password");
                await userManager.AddToRoleAsync(admin, "admin");
                await userManager.AddToRoleAsync(chuyenvien, "chuyenvien");
                await userManager.AddToRoleAsync(congtrinh, "congtrinh");
            }
        }
    }
}
