using System.ComponentModel.DataAnnotations;

namespace CarteleraCine.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "El título debe tener entre {2} y {1} caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Director")]
        [Required(ErrorMessage = "El nombre del director es obligatorio.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre del director debe tener entre {2} y {1} caracteres.")]
        public string Director { get; set; } = string.Empty;

        [Display(Name = "Duración (minutos)")]
        [Required(ErrorMessage = "La duración es obligatoria.")]
        [Range(1, 600, ErrorMessage = "La duración debe estar entre {1} y {2} minutos.")]
        public int DuracionMinutos { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un género.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un género válido.")]
        [Display(Name = "Género")]
        public int GeneroId { get; set; }

        [Display(Name = "Género")]
        public Genero? Genero { get; set; }
    }
}
