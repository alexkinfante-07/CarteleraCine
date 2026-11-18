using System.ComponentModel.DataAnnotations;

namespace CarteleraCine.Models
{
    public class Pelicula
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "El título es obligatorio.")]
        [StringLength(100, ErrorMessage = "El título no puede superar los 100 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Display(Name = "Director")]
        [Required(ErrorMessage = "El nombre del director es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del director no puede superar los 100 caracteres.")]
        public string Director { get; set; } = string.Empty;

        [Display(Name = "Duración (minutos)")]
        [Required(ErrorMessage = "La duración es obligatoria.")]
        [Range(1, 600, ErrorMessage = "La duración debe estar entre 1 y 600 minutos.")]
        public int DuracionMinutos { get; set; }
    }
}
