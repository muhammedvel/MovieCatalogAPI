using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Data;
using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Controllers;

[ApiController] 
[Route("api/[controller]")] 
public class MoviesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public MoviesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(
        [FromQuery] string? genre, 
        [FromQuery] string? search, 
        [FromQuery] int pageNumber = 1, 
        [FromQuery] int pageSize = 10)
    {
        var query = _context.Movies.AsQueryable();

        if (!string.IsNullOrWhiteSpace(genre))
        {
            query = query.Where(m => m.Genre!.ToLower() == genre.ToLower());
        }

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(m => m.Title!.ToLower().Contains(search.ToLower()));
        }

        var skipResults = (pageNumber - 1) * pageSize;

        return await query.Skip(skipResults).Take(pageSize).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);

        if (movie == null)
        {
            return NotFound("Movie not found!");
        }

        return movie;
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> PostMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMovie(int id, Movie movie)
    {
        if (id != movie.Id)
        {
            return BadRequest("ID-то в адреса не съвпада с ID-то на филма!");
        }

        _context.Entry(movie).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Movies.Any(e => e.Id == id))
            {
                return NotFound("Филмът не е намерен!");
            }
            else
            {
                throw;
            }
        }

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        
        if (movie == null)
        {
            return NotFound("Филмът не е намерен!");
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent(); 
    }
}