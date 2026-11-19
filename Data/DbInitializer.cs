using Microsoft.AspNetCore.Identity;

namespace CarteleraCine.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<CarteleraCine.Models.ApplicationUser>>();

            string[] roles = { "Curador", "Espectador" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            await CreateUserWithRoleAsync(userManager, "curador@cine.com", "Cine2026*", "Curador");
            await CreateUserWithRoleAsync(userManager, "espectador@cine.com", "Cine2026*", "Espectador");
        }

        private static async Task CreateUserWithRoleAsync(
            UserManager<CarteleraCine.Models.ApplicationUser> userManager,
            string email,
            string password,
            string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new CarteleraCine.Models.ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    return;
                }
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }
    }
}