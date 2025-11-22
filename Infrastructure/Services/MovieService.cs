using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace Infrastructure.Services;

public class MovieService: IMovieService
{
    private readonly IMovieRepository movieRepository;
    public MovieService(IMovieRepository _movieRepository)
    {
        movieRepository = _movieRepository;
    }
    // get the top 20 movie
    public List<MovieCardModel> Top20Movies()
    {
        var movies = movieRepository.GetTop20Movies();
        var movieCardModels = new List<MovieCardModel>();
        foreach (var movie in movies)
        {
            movieCardModels.Add(new MovieCardModel()
            {
                Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title
            });
        }

        return movieCardModels;
    }

    public async Task<IEnumerable<Movie>> GetMoviesByGenreAsync(int genreId)
    {
        // Using Task.Run just for async in this example
        return await Task.Run(() => movieRepository.GetMoviesByGenreAsync(genreId));
    }

    public MovieDetailsModel GetMovieDetails(int id)
    {
        var movies = movieRepository.GetMovieByIdWithGenres(id);
        if (movies != null)
        {
            var movieDetailsModel = new MovieDetailsModel()
            {
                Id = movies.Id,
                Title = movies.Title,
                Overview = movies.Overview,
                Tagline = movies.Tagline,
                Budget = movies.Budget,
                Revenue = movies.Revenue,
                BackdropUrl = movies.BackdropUrl,
                ImdbUrl = movies.ImdbUrl,
                TmdbUrl = movies.TmdbUrl,
                ReleaseDate = movies.ReleaseDate,
                RunTime = movies.RunTime,
                Price = movies.Price,
                PosterUrl = movies.PosterUrl,
            };
            movieDetailsModel.Genres = new List<GenreModel>();
            foreach (var genre in movies.MovieGenres)
                movieDetailsModel.Genres.Add(new GenreModel
                {
                    Id = genre.GenreId, Name = genre.Genre.Name
                });
            return movieDetailsModel;
        }
        return null;
    }
}