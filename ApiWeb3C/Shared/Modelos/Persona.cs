using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb3C.Shared.Modelos
{
    public class Persona
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe escribir el nombre")]
        [StringLength(100)]
        public string? Nombre { get; set; }
        [Required(ErrorMessage ="Debe escribir el teléfono")]
        [StringLength(20)]
        public string? Telefono { get; set; }
        [Required(ErrorMessage ="Debe escribir el correo")]
        [StringLength(50)]
        public string? Correo { get; set; }

        public int ClasificacionId { get; set; }
        public virtual Clasificacion? Clasificacion { get; set; }

    }
}
