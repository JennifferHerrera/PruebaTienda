using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTienda.EntidadesDeNegocio
{
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Descripcion es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Precio es obligatorio")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Cantidad disponible es obligatorio")]
        public int CantidadDisponible { get; set; }
        [ForeignKey("Categoria")]
        [Required(ErrorMessage = "Categoria es obligatorio")]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
