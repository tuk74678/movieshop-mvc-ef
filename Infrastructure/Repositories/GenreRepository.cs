using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenreRepository: BaseRepository<Genre>, IGenreRepository
{
    public GenreRepository(MovieShopDbContext dbContext) : base(dbContext)
    {
        
    }

    public IEnumerable<Genre> GetAllGenres()
    {
        var genres = _movieShopDbContext.Genres.ToList();
        return genres;
    }
    
}