using System.ComponentModel.DataAnnotations;

namespace CarteleraCine.Models
{
    public class Genero
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre del género es obligatorio.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre {2} y {1} caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "Descripción")]
        [StringLength(200, ErrorMessage = "La descripción no puede superar los {1} caracteres.")]
        public string? Descripcion { get; set; }

        public ICollection<Pelicula> Peliculas { get; set; } = new List<Pelicula>();
    }
}
