using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models
{
    public class Factura
    {
        [Required(ErrorMessage = "El número de factura es requerido")]
        public int NumeroFactura { get; set; }

        [Required(ErrorMessage = "La fecha de expedición de la factura es requerida")]
        public DateTime FechaExpedicion { get; set; }

        [Required(ErrorMessage = "El cliente es requerido")]
        public int ClienteId { get; set; }

        public virtual Cliente? Cliente { get; set; }

        public virtual ICollection<ItemVenta>? ItemsVenta { get; set; }
    }
}