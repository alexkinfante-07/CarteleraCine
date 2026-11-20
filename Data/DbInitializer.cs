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

            var context = scope.ServiceProvider.GetRequiredService<CarteleraCineContext>();
            if (!context.Genero.Any())
            {
                context.Genero.AddRange(
                    new CarteleraCine.Models.Genero { Nombre = "Acción", Descripcion = "Películas con secuencias de acción, persecuciones y combates." },
                    new CarteleraCine.Models.Genero { Nombre = "Comedia", Descripcion = "Películas diseñadas para divertir y provocar risas." },
                    new CarteleraCine.Models.Genero { Nombre = "Drama", Descripcion = "Historias con desarrollo profundo de conflictos humanos y emocionales." },
                    new CarteleraCine.Models.Genero { Nombre = "Ciencia Ficción", Descripcion = "Historias sobre avances tecnológicos, futuros hipotéticos y el cosmos." }
                );
                await context.SaveChangesAsync();
            }
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