using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTienda.EntidadesDeNegocio
{
    public class Venta
    {
        [Key]
        public int IdVenta { get; set; }
        [Display(Name = "Fecha de Venta")]
        public DateTime FechaDeVenta { get; set; }
        [Required(ErrorMessage = "Monto total es obligatorio")]
        public decimal MontoTotal { get; set; }
        [ForeignKey("Usuario")]
        [Required(ErrorMessage = "Usuario es obligatorio")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        [ForeignKey("Cliente")]
        [Required(ErrorMessage = "Cliente es obligatorio")]
        [Display(Name = "Cliente")]
        public int IdCliente { get; set; }
        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }
    }
}
