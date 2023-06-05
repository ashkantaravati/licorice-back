using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicoriceBack.Data;
using LicoriceBack.Models;

namespace LicoriceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubesController : ControllerBase
    {
        private readonly LicoriceBackContext _context;

        public CubesController(LicoriceBackContext context)
        {
            _context = context;
        }

        // GET: api/Cube
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cube>>> GetCube()
        {
          if (_context.Cubes == null)
          {
              return NotFound();
          }
            return await _context.Cubes.ToListAsync();
        }

        // GET: api/Cube/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cube>> GetCube(int id)
        {
          if (_context.Cubes == null)
          {
              return NotFound();
          }
            var cube = await _context.Cubes.FindAsync(id);

            if (cube == null)
            {
                return NotFound();
            }

            return cube;
        }

        // PUT: api/Cube/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCube(int id, Cube cube)
        {
            if (id != cube.Id)
            {
                return BadRequest();
            }

            _context.Entry(cube).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CubeExists(id))
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

        // POST: api/Cube
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cube>> PostCube(Cube cube)
        {
          if (_context.Cubes == null)
          {
              return Problem("Entity set 'LicoriceBackContext.Cubes'  is null.");
          }
            _context.Cubes.Add(cube);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCube", new { id = cube.Id }, cube);
        }

        // DELETE: api/Cube/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCube(int id)
        {
            if (_context.Cubes == null)
            {
                return NotFound();
            }
            var cube = await _context.Cubes.FindAsync(id);
            if (cube == null)
            {
                return NotFound();
            }

            _context.Cubes.Remove(cube);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CubeExists(int id)
        {
            return (_context.Cubes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
