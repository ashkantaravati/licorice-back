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
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using LicoriceBack.Utils;

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


        [HttpPost]
        public async Task<ActionResult<Cube>> PostCube(CubeCreationDto dto)
        {
          if (_context.Cubes == null)
          {
              return Problem("Entity set 'LicoriceBackContext.Cubes'  is null.");
          }

            var wall = await _context.Walls.FirstOrDefaultAsync(wall => wall.Key == dto.WallKey);
            if(wall == null)
            {
                return BadRequest("Wall does not exist");
            }
            if(dto.Passphrase!= dto.PassphraseConfirmation)
            {
                return BadRequest("Passphrase and Passphrase Repeat do not match!");
            }
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
            var passphraseHash = BCrypt.Net.BCrypt.HashPassword(dto.Passphrase);
            Cube cube = new Cube
            {
                Key=UniqueKeyUtils.GenerateUniqueKey("B"),
                CreatedAt = DateTime.Now,
                Name = dto.Name,
                Wall = wall,
                PassphraseHash = passphraseHash

            };
            _context.Cubes.Add(cube);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCube", new { key = cube.Key }, cube);
        }
        [HttpPost("unlock")]
        public async Task<ActionResult<CubeDetailsDto>> UnlockCube(CubeUnlockDto dto)
        {
            if (_context.Cubes == null)
            {
                return NotFound();
            }
            var cube = await _context.Cubes.Include(c => c.Cards).FirstOrDefaultAsync(c => c.Key == dto.Key);

            if (cube == null)
            {
                return BadRequest("Specified Cube Does Not Exist!");
            }

            bool verified = BCrypt.Net.BCrypt.Verify(dto.Passphrase, cube.PassphraseHash);

            if (verified)
            {
                var response = new CubeDetailsDto
                {
                    Name = cube.Name,
                    Key = cube.Key,
                    Cards = cube.Cards.Select(c => new CardOverviewDto
                    {
                        Content = c.Content,
                        CreatedAt = c.CreatedAt
                    }).ToList()
                };
                return response;
            }

            return Unauthorized("Invalid Passphrase");
        }

    }
}
