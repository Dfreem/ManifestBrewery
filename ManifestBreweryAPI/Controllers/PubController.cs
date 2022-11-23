using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ManifestBreweryClasses.Models;

namespace ManifestBreweryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubController : ControllerBase
    {
        private readonly ManifestBreweryContext _context;

        public PubController(ManifestBreweryContext context)
        {
            _context = context;
        }

        // GET: api/Pub
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pub>>> GetPubs()
        {
          if (_context.Pubs == null)
          {
              return NotFound();
          }
            return await _context.Pubs.ToListAsync();
        }

        // GET: api/Pub/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pub>> GetPub(int id)
        {
          if (_context.Pubs == null)
          {
              return NotFound();
          }
            var pub = await _context.Pubs.FindAsync(id);

            if (pub == null)
            {
                return NotFound();
            }

            return pub;
        }

        // PUT: api/Pub/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPub(int id, Pub pub)
        {
            if (id != pub.PubId)
            {
                return BadRequest();
            }

            _context.Entry(pub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PubExists(id))
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

        // POST: api/Pub
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pub>> PostPub(Pub pub)
        {
          if (_context.Pubs == null)
          {
              return Problem("Entity set 'ManifestBreweryContext.Pubs'  is null.");
          }
            _context.Pubs.Add(pub);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPub", new { id = pub.PubId }, pub);
        }

        // DELETE: api/Pub/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePub(int id)
        {
            if (_context.Pubs == null)
            {
                return NotFound();
            }
            var pub = await _context.Pubs.FindAsync(id);
            if (pub == null)
            {
                return NotFound();
            }

            _context.Pubs.Remove(pub);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PubExists(int id)
        {
            return (_context.Pubs?.Any(e => e.PubId == id)).GetValueOrDefault();
        }
    }
}
