using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Uppgift4.Models;

namespace Uppgift4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CDsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CDsController(DatabaseContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        // GET: api/CDs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CD>>> GetCD()
        {
            return await _context.CD.Include(c => c.Artist).ToListAsync();
        }

        // GET: api/CDs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CD>> GetCD(int id)
        {
            var cD = await _context.CD.FindAsync(id);

            if (cD == null)
            {
                return NotFound();
            }

            return cD;
        }

        // PUT: api/CDs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCD(int id, CD cD)
        {
            if (id != cD.ID)
            {
                return BadRequest();
            }

            _context.Entry(cD).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CDExists(id))
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

        // POST: api/CDs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CD>> PostCD(CD cD)
        {
            _context.CD.Add(cD);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCD", new { id = cD.ID }, cD);
        }

        // DELETE: api/CDs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCD(int id)
        {
            var cD = await _context.CD.FindAsync(id);
            if (cD == null)
            {
                return NotFound();
            }

            _context.CD.Remove(cD);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CDExists(int id)
        {
            return _context.CD.Any(e => e.ID == id);
        }
    }
}
