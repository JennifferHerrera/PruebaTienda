using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTienda.EntidadesDeNegocio
{
    public class DetalleVenta
    {
        [Key]
        public int IdDetalleVenta { get; set; }
        [ForeignKey("Venta")]
        [Required(ErrorMessage = "Venta es obligatorio")]
        [Display(Name = "Venta")]
        public int IdVenta { get; set; }
        [ForeignKey("Producto")]
        [Required(ErrorMessage = "Producto es obligatorio")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Cantidad de Producto es obligatorio")]
        public int CantidadProducto { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
