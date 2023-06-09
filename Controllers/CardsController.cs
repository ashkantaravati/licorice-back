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

namespace LicoriceBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly LicoriceBackContext _context;

        public CardsController(LicoriceBackContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Card>> PostCard(CardCreationDto dto)
        {
            if (_context.Cards == null)
            {
                return Problem("Entity set 'LicoriceBackContext.Cards'  is null.");
            }
            var cube = await _context.Cubes.FirstOrDefaultAsync(cube => cube.Key == dto.CubeKey);
            if (cube == null)
            { return BadRequest("No cube with specified key exists"); }
            var card = new Card
            {
                Content = dto.Content,
                Cube = cube,
                CreatedAt = DateTime.Now

            };
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostCard", dto);
        }

    }
}
