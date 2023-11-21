using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb3C.Shared.Modelos
{
    public class Clasificacion
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Debe colocar un nombre"), StringLength(100, ErrorMessage ="No mayor a 100 caracteres")]
        public string? Nombre { get; set; }

        public virtual ICollection<Persona>? Personas { get; set; }
    }
}
