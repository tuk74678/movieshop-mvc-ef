using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    Task<IEnumerable<Movie>> GetTop20MoviesAsync();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
    Task<Movie> GetMovieById(int id);
}