using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musica_AdrianJimenez.Data;
using Musica_AdrianJimenez.Models;

namespace Musica_AdrianJimenez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArtistsController : ControllerBase
    {
        private readonly ChinookContext _context;

        public ArtistsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await _context.Artists
                .Include(a => a.Albums)
                .OrderBy(n => n.Name)
                .Take(10)
                .ToListAsync();
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await _context.Artists
                .Include(a => a.Albums)
                .Where(a => a.ArtistId == id)
                .FirstAsync();

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        // PUT: api/Artists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "admin,manager")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if(ModelState.IsValid)
            {
                if (id != artist.ArtistId)
                {
                    return BadRequest();
                }

                _context.Entry(artist).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArtistExists(id))
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
            return BadRequest();

        }

        // POST: api/Artists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "admin,manager")]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            if(ModelState.IsValid)
            {
                _context.Artists.Add(artist);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
            }
            return BadRequest();
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin,manager")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null)
            {
                return NotFound();
            }

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistExists(int id)
        {
            return _context.Artists.Any(e => e.ArtistId == id);
        }
    }
}
