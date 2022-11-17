using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(150)]
        public string Apellido { get; set; } = string.Empty;

        [MaxLength(350)]
        public string? Direccion { get; set; }

        [MaxLength(50)]
        public string? Telefono { get; set; }

        [MaxLength(350)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }

    }
}
