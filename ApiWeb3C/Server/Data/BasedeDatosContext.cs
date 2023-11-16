using ApiWeb3C.Shared.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb3C.Server.Data
{
    public class BasedeDatosContext : DbContext
    {
        public BasedeDatosContext(DbContextOptions<BasedeDatosContext> options) : base(options)
        {

        }

        public DbSet<Persona> Personas { get; set; }
    }
}
