using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogAPI.Data;
using MovieCatalogAPI.Models;

namespace MovieCatalogAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ReviewsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("movie/{movieId}")]
    public async Task<ActionResult<IEnumerable<Review>>> GetReviewsForMovie(int movieId)
    {
        return await _context.Reviews.Where(r => r.MovieId == movieId).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Review>> PostReview(Review review)
    {
        var movieExists = await _context.Movies.AnyAsync(m => m.Id == review.MovieId);
        
        if (!movieExists)
        {
            return BadRequest("Филмът с това ID не съществува!");
        }

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        return Ok(review);
    }
}