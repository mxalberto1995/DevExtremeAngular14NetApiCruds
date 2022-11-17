using System.ComponentModel.DataAnnotations;

namespace Facturacion.Models
{
    public class ItemVenta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El número de factura es requerido")]
        public int NumeroFactura { get; set; }

        [Required(ErrorMessage = "El producto es requerido")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El precio unitario es requerido")]
        public decimal PrecioUnitario { get; set; }

        [Required(ErrorMessage = "La cantidad es requerida")]
        public int CantidadVendida { get; set; }

        public virtual Factura? Factura { get; set; }

        public virtual Producto? Producto { get; set; }
    }
}
