using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTienda.EntidadesDeNegocio
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Direccion es obligatorio")]
        [StringLength(70, ErrorMessage = "Maximo 70 caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Telefono es obligatorio")]
        public int Telefono { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Venta> Venta { get; set; }
    }
}
