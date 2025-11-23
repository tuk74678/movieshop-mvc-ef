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
    public IEnumerable<Movie> GetTop20Movies()
    {
        var movies = _movieShopDbContext.Movies.OrderByDescending(m=> m.Revenue).Take(20);
        return movies;
    }
    
    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        return await _movieShopDbContext.Movies
            .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
            .ToListAsync();
    }
    // Get a single movie by Id including genres
    public Movie GetMovieById(int id)
    {
        return _movieShopDbContext.Movies
            .Include(m => m.MovieGenres).ThenInclude(mg => mg.Genre)
            .Include(m=> m.MovieCasts).ThenInclude(m => m.Cast)
            .FirstOrDefault(m => m.Id == id);
    }
    
}