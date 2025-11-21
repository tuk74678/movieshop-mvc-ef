using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

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
  
}