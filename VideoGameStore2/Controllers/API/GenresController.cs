using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameStore2.Models;

namespace VideoGameStore2.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly GameStoreDBContext _context;

        public GenresController(GameStoreDBContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public IEnumerable<Genre> GetGenre()
        {
            return _context.Genre;
        }

        // GET: api/Genres/GetGamesInGenre
        [HttpGet("GetGamesInGenre/{id}")]
        public IActionResult GetGamesInGenre([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = _context.Genre.Include(x=>x.Games).Single(x=>x.GenreId==id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre.Games);
        }


        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGenre([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = await _context.Genre.FindAsync(id);

            if (genre == null)
            {
                return NotFound();
            }

            return Ok(genre);
        }



        // POST: api/Genres
        [HttpPost]
        public async Task<IActionResult> PostGenre([FromBody] Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Genre.Add(genre);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenre", new { id = genre.GenreId }, genre);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var genre = await _context.Genre.FindAsync(id);
            if (genre == null)
            {
                return NotFound();
            }

            _context.Genre.Remove(genre);
            await _context.SaveChangesAsync();

            return Ok(genre);
        }

        private bool GenreExists(int id)
        {
            return _context.Genre.Any(e => e.GenreId == id);
        }
    }
}