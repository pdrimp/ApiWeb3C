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
    public class HabitosController : ControllerBase
    {
        private readonly BasedeDatosContext _context;

        public HabitosController(BasedeDatosContext context)
        {
            _context = context;
        }

        // GET: api/Habitos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habito>>> GetHabitos()
        {
          if (_context.Habitos == null)
          {
              return NotFound();
          }
            return await _context.Habitos.ToListAsync();
        }

        // GET: api/Habitos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Habito>> GetHabito(int id)
        {
          if (_context.Habitos == null)
          {
              return NotFound();
          }
            var habito = await _context.Habitos.FindAsync(id);

            if (habito == null)
            {
                return NotFound();
            }

            return habito;
        }

        // PUT: api/Habitos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabito(int id, Habito habito)
        {
            if (id != habito.Id)
            {
                return BadRequest();
            }

            _context.Entry(habito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitoExists(id))
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

        // POST: api/Habitos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Habito>> PostHabito(Habito habito)
        {
          if (_context.Habitos == null)
          {
              return Problem("Entity set 'BasedeDatosContext.Habitos'  is null.");
          }
            _context.Habitos.Add(habito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabito", new { id = habito.Id }, habito);
        }

        // DELETE: api/Habitos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabito(int id)
        {
            if (_context.Habitos == null)
            {
                return NotFound();
            }
            var habito = await _context.Habitos.FindAsync(id);
            if (habito == null)
            {
                return NotFound();
            }

            _context.Habitos.Remove(habito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HabitoExists(int id)
        {
            return (_context.Habitos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
