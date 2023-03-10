using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTienda.EntidadesDeNegocio
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        [ForeignKey("Rol")]
        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "Maximo 20 caracteres")]
        public string Nombre { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Usuario> Usuario { get; set; }
    }
}
