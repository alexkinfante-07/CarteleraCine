using Microsoft.EntityFrameworkCore;

public class CarteleraCineContext(DbContextOptions<CarteleraCineContext> options) : DbContext(options)
{
    public DbSet<CarteleraCine.Models.Pelicula> Pelicula { get; set; } = default!;
    public DbSet<CarteleraCine.Models.Genero> Genero { get; set; } = default!;
}
