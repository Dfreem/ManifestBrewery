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
    public class PubEmployeeController : ControllerBase
    {
        private readonly ManifestBreweryContext _context;

        public PubEmployeeController(ManifestBreweryContext context)
        {
            _context = context;
        }

        // GET: api/PubEmployee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PubEmployee>>> GetPubEmployees()
        {
          if (_context.PubEmployees == null)
          {
              return NotFound();
          }
            return await _context.PubEmployees.ToListAsync();
        }

        // GET: api/PubEmployee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PubEmployee>> GetPubEmployee(int id)
        {
          if (_context.PubEmployees == null)
          {
              return NotFound();
          }
            var pubEmployee = await _context.PubEmployees.FindAsync(id);

            if (pubEmployee == null)
            {
                return NotFound();
            }

            return pubEmployee;
        }

        // PUT: api/PubEmployee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPubEmployee(int id, PubEmployee pubEmployee)
        {
            if (id != pubEmployee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(pubEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PubEmployeeExists(id))
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

        // POST: api/PubEmployee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PubEmployee>> PostPubEmployee(PubEmployee pubEmployee)
        {
          if (_context.PubEmployees == null)
          {
              return Problem("Entity set 'ManifestBreweryContext.PubEmployees'  is null.");
          }
            _context.PubEmployees.Add(pubEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPubEmployee", new { id = pubEmployee.EmployeeId }, pubEmployee);
        }

        // DELETE: api/PubEmployee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePubEmployee(int id)
        {
            if (_context.PubEmployees == null)
            {
                return NotFound();
            }
            var pubEmployee = await _context.PubEmployees.FindAsync(id);
            if (pubEmployee == null)
            {
                return NotFound();
            }

            _context.PubEmployees.Remove(pubEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PubEmployeeExists(int id)
        {
            return (_context.PubEmployees?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        }
    }
}
