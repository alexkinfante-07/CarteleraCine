using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class CarteleraCineContext(DbContextOptions<CarteleraCineContext> options)
    : IdentityDbContext<CarteleraCine.Models.ApplicationUser>(options)
{
    public DbSet<CarteleraCine.Models.Pelicula> Pelicula { get; set; } = default!;
    public DbSet<CarteleraCine.Models.Genero> Genero { get; set; } = default!;
}
