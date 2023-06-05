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
    public class WallsController : ControllerBase
    {
        private readonly LicoriceBackContext _context;

        public WallsController(LicoriceBackContext context)
        {
            _context = context;
        }

        // GET: api/Walls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wall>>> GetWall()
        {
          if (_context.Walls == null)
          {
              return NotFound();
          }
            return await _context.Walls.Include(g=>g.Cubes).ToListAsync();
        }

        // GET: api/Walls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wall>> GetWall(int id)
        {
          if (_context.Walls == null)
          {
              return NotFound();
          }
            var wall = await _context.Walls.FindAsync(id);

            if (wall == null)
            {
                return NotFound();
            }

            return wall;
        }

        // PUT: api/Walls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWall(int id, Wall wall)
        {
            if (id != wall.Id)
            {
                return BadRequest();
            }

            _context.Entry(wall).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WallExists(id))
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

        // POST: api/Walls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wall>> PostWall(Wall wall)
        {
          if (_context.Walls == null)
          {
              return Problem("Entity set 'LicoriceBackContext.Gathering'  is null.");
          }
            _context.Walls.Add(wall);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWall", new { id = wall.Id }, wall);
        }

        // DELETE: api/Walls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWall(int id)
        {
            if (_context.Walls == null)
            {
                return NotFound();
            }
            var wall = await _context.Walls.FindAsync(id);
            if (wall == null)
            {
                return NotFound();
            }

            _context.Walls.Remove(wall);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WallExists(int id)
        {
            return (_context.Walls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
