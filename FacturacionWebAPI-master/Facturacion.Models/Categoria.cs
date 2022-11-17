using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [MaxLength(150)]
        public string NombreCategoria { get; set; } = string.Empty;

        public virtual ICollection<Producto>? Productos { get; set; }
    }
}
