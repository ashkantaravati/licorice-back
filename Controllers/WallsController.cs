using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicoriceBack.Data;
using LicoriceBack.Models;
using LicoriceBack.Contracts;
using LicoriceBack.Utils;

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
        public async Task<ActionResult<IEnumerable<WallOverviewDto>>> GetWall()
        {
          if (_context.Walls == null)
          {
              return NotFound();
          }

            var walls = await _context.Walls.Include(g => g.Cubes).Select(w => new WallOverviewDto
            {
                Title = w.Title,
                Creator = w.Creator,
                IsPublic = w.IsPublic,
                Key = w.Key,
                CubeCount = w.Cubes.Count()

            }).ToListAsync();
            return walls;
        }

        // GET: api/Walls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WallDetailsDto>> GetWall(string id)
        {
          if (_context.Walls == null)
          {
              return NotFound();
          }
            var wall = await _context.Walls.Include(w => w.Cubes).Select(w => new WallDetailsDto
            {
                Descriptions = w.Descriptions,
                Key = w.Key,
                Creator = w.Creator,
                Cubes = w.Cubes.Select(c => new CubeOverviewDto { 
                Key=c.Id.ToString(),
                Name=c.Name,
                CardCount=c.Cards.Count()
                }).ToList(),
                CubeCount = w.Cubes.Count()
            }).FirstOrDefaultAsync(w => w.Key == id);

            if (wall == null)
            {
                return NotFound();
            }
            return wall;
        }

        [HttpPost]
        public async Task<ActionResult<Wall>> PostWall(CreateWallDto dto)
        {
          if (_context.Walls == null)
          {
              return Problem("Entity set 'LicoriceBackContext.Walls'  is null.");
          }

            var wall = new Wall
            {
                Title = dto.Title,
                Creator = dto.Creator,
                IsPublic = dto.IsPublic,
                Descriptions = dto.Descriptions,
                CreateAt = DateTime.Now,
                Key = UniqueKeyUtils.GenerateUniqueKey()

            };
            _context.Walls.Add(wall);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWall", new { id = wall.Key }, wall);
        }

    }
}
