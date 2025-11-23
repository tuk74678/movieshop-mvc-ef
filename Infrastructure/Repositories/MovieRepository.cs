using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class MovieRepository: BaseRepository<Movie>, IMovieRepository
{
    public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
        
    }
    // Optimized: Top 20 movies, read-only, only necessary columns
    public async Task<IEnumerable<Movie>> GetTop20MoviesAsync()
    {
        var movies = await _movieShopDbContext.Movies
            .AsNoTracking() // read-only
            .OrderByDescending(m => m.Revenue)
            .Take(20)
            .Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl,
                Revenue = m.Revenue
            })
            .ToListAsync();

        return movies;
    }
    
    // Optimized: Get movies by genre, async, read-only
    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        return await _movieShopDbContext.Movies
            .AsNoTracking()
            .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
            .Select(m => new Movie
            {
                Id = m.Id,
                Title = m.Title,
                PosterUrl = m.PosterUrl,
                Revenue = m.Revenue
            })
            .ToListAsync();
    }
    // Get a single movie by Id including genres
    // Optimized: Get single movie by Id with necessary navigation properties
    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        return await _movieShopDbContext.Movies
            .AsNoTracking()
            .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
            .Include(m => m.MovieCasts).ThenInclude(mc => mc.Cast)
            .Include(m => m.Trailers)
            .FirstOrDefaultAsync(m => m.Id == id);
    }
    
}