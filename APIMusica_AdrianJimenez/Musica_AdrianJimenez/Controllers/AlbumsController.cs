using System;
using System.Collections.Generic;
using System.Data;
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
    public class AlbumsController : ControllerBase
    {
        private readonly ChinookContext _context;

        public AlbumsController(ChinookContext context)
        {
            _context = context;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums
               .Include(a => a.Artist)
               .Include(t => t.Tracks)
               .OrderByDescending(a => a.Title)
               .Take(10)
               .ToListAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            Album album = await _context.Albums
                .Include(a => a.Artist)
                .Include(t => t.Tracks)
                .Where(album => album.AlbumId == id)
                .FirstAsync();

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "admin,manager")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if(ModelState.IsValid)
            {
                if (id != album.AlbumId)
                {
                    return BadRequest("El ÁlbumId tiene que ser en los parámetros y el cuerpo");
                }
                _context.Entry(album).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(id))
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

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(Roles = "admin,manager")]
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Albums.Add(album);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
            }
            return BadRequest();
        }

        // DELETE: api/Albums/5
        [Authorize(Roles = "admin,manager")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumId == id);
        }
    }
}
