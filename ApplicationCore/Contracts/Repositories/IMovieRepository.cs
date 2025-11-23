using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IMovieRepository: IRepository<Movie>
{
    IEnumerable<Movie> GetTop20Movies();
    Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId);
    Movie GetMovieById(int id);
}