using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiWeb3C.Shared.Modelos
{
    public class Habito
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public virtual ICollection<Persona>? Personas { get; set; }
    }
}
