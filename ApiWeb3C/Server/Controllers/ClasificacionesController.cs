using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWeb3C.Server.Data;
using ApiWeb3C.Shared.Modelos;

namespace ApiWeb3C.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasificacionesController : ControllerBase
    {
        private readonly BasedeDatosContext _context;

        public ClasificacionesController(BasedeDatosContext context)
        {
            _context = context;
        }

        // GET: api/Clasificaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clasificacion>>> GetClasificaciones()
        {
          if (_context.Clasificaciones == null)
          {
              return NotFound();
          }
            return await _context.Clasificaciones.ToListAsync();
        }

        // GET: api/Clasificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clasificacion>> GetClasificacion(int id)
        {
          if (_context.Clasificaciones == null)
          {
              return NotFound();
          }
            var clasificacion = await _context.Clasificaciones.FindAsync(id);

            if (clasificacion == null)
            {
                return NotFound();
            }

            return clasificacion;
        }

        // PUT: api/Clasificaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClasificacion(int id, Clasificacion clasificacion)
        {
            if (id != clasificacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(clasificacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClasificacionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Clasificaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clasificacion>> PostClasificacion(Clasificacion clasificacion)
        {
          if (_context.Clasificaciones == null)
          {
              return Problem("Entity set 'BasedeDatosContext.Clasificaciones'  is null.");
          }
            _context.Clasificaciones.Add(clasificacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClasificacion", new { id = clasificacion.Id }, clasificacion);
        }

        // DELETE: api/Clasificaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClasificacion(int id)
        {
            if (_context.Clasificaciones == null)
            {
                return NotFound();
            }
            var clasificacion = await _context.Clasificaciones.FindAsync(id);
            if (clasificacion == null)
            {
                return NotFound();
            }

            _context.Clasificaciones.Remove(clasificacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClasificacionExists(int id)
        {
            return (_context.Clasificaciones?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
